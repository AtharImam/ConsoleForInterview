using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleForInterview
{
    public class JobPostingSearchDTO
    {
        /// <summary>
        /// Gets and sets Primary key value.
        /// </summary>
        public long PostingKey { get; set; }

        /// <summary>
        /// Gets and sets Parent Skill Id.
        /// </summary>
        public long ParentSkillId { get; set; }

        /// <summary>
        /// Gets and sets Is Archive value.
        /// </summary>
        public bool IsArchived { get; set; }

        public override bool Equals(object obj)
        {
            return obj is JobPostingSearchDTO dTO &&
                   PostingKey == dTO.PostingKey &&
                   ParentSkillId == dTO.ParentSkillId &&
                   IsArchived == dTO.IsArchived;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PostingKey, ParentSkillId, IsArchived);
        }
    }
}