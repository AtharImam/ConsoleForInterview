using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleForInterview.DesignPatterns
{
    public class DecoratorPattern
    {
        public static void Execute()
        {
            PizzaDecorator.Execute();
        }

        public class PizzaDecorator
        {
            public static void Execute()
            {
                List<Pizza> pizzas = new List<Pizza>();
                pizzas.Add(new Pizza { Crust = Crust.Regular, Price = 100, Size = Size.Medium });
                pizzas.Add(new Pizza { Crust = Crust.Stuffed, Price = 150, Size = Size.Medium });
                pizzas.Add(new Pizza { Crust = Crust.Thin, Price = 50, Size = Size.Large });
                pizzas.Add(new Pizza { Crust = Crust.Stuffed, Price = 150, Size = Size.Medium });
                pizzas.Add(new Pizza { Crust = Crust.Regular, Price = 100, Size = Size.Large });

                PizzaOrder pizzaOrder = new PizzaOrder { Pizzas = pizzas };

                PizzaOrderingSystem orderingSystem = new PizzaOrderingSystem(Policies.DiscountAllThePizzas());
                decimal price = orderingSystem.ComputePrice(pizzaOrder);

                Console.WriteLine($"Discounted Price: {price}");
            }

            delegate decimal DiscountPolicy(PizzaOrder order);

            internal enum Size { Small, Medium, Large }

            enum Crust { Thin, Regular, Stuffed }

            class BestDiscount
            {
                readonly List<DiscountPolicy> policies;

                public BestDiscount(List<DiscountPolicy> policies)
                {
                    this.policies = policies;
                }

                public decimal ComputePolicy(PizzaOrder order)
                {
                    return policies.Max(policy => policy.Invoke(order));
                }
            }

            static class Policies
            {
                public static decimal BueOneGetOneFree(PizzaOrder order)
                {
                    var pizzas = order.Pizzas;
                    if (pizzas.Count < 2)
                    {
                        return 0m;
                    }

                    decimal discount = pizzas.Min(pizza => pizza.Price);
                    return discount;
                }

                public static decimal FivePercentOffMoreThanFiftyDollars(PizzaOrder order)
                {
                    decimal nonDiscounted = order.Pizzas.Sum(p => p.Price);
                    decimal discount = nonDiscounted >= 50 ? nonDiscounted * 0.05m : 0m;
                    return discount;
                }

                public static decimal FiveDollarOffStuffedCrust(PizzaOrder order)
                {
                    decimal discount = order.Pizzas.Sum(pizza => pizza.Crust == Crust.Stuffed ? 5m : 0);
                    return discount;
                }

                public static DiscountPolicy CreateBest(params DiscountPolicy[] policies)
                {
                    DiscountPolicy policy = order => policies.Max(policy => policy.Invoke(order));
                    return policy;
                }

                public static DiscountPolicy DiscountAllThePizzas()
                {
                    DiscountPolicy policy = CreateBest(BueOneGetOneFree, FivePercentOffMoreThanFiftyDollars, FiveDollarOffStuffedCrust);
                    return policy;
                }
            }

            class Pizza
            {
                public Size Size { get; set; }

                public Crust Crust { get; set; }

                public decimal Price { get; set; }
            }

            class PizzaOrder
            {
                public List<Pizza> Pizzas { get; set; }
            }

            class PizzaOrderingSystem
            {
                readonly DiscountPolicy discountPolicy;

                public PizzaOrderingSystem(DiscountPolicy discountPolicy)
                {
                    this.discountPolicy = discountPolicy;
                }

                public decimal ComputePrice(PizzaOrder order)
                {
                    decimal nonDiscounted = order.Pizzas.Sum(p => p.Price);
                    decimal discountValue = discountPolicy(order);
                    return nonDiscounted - discountValue;
                }
            }
        }
    }
}
