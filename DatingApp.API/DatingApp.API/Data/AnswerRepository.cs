using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Data
{
    public class AnswerRepository: IAnswerRepository
    {
        private DataContext _context;
        public AnswerRepository(DataContext context)
        {
            _context = context;
        }
    }
}

