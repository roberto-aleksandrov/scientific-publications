using AutoMapper;
using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Features.Authors.Models;
using System.Collections.Generic;

namespace ScientificPublications.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : BaseRequest<AuthorDto>
    {
        public int UserId { get; set; }

        public string ScopusId { get; set; }

        public bool IsCathedralMember { get; set; }

        public ICollection<string> Aliases { get; set; }
    }
}
