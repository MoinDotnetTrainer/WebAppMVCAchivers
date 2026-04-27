using MyProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLibrary.Interfaces
{
    public interface IAadhar
    {
        Task<List<Aadhar>> GetAadharData();

        Task<List<Pan>> GetPanData();
    }
}
