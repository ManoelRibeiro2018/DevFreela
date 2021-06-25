using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModel
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, DateTime createdAd)
        {
            Id = id;
            Title = title;
            CreatedAd = createdAd;
        }
        public int Id { get; private set; }

        public string Title { get; private set; }
        public DateTime CreatedAd { get; private set; }
    }
}
