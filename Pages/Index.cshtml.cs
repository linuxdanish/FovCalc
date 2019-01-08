using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FovCalc.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public double senW { get; set; }

        [BindProperty]
        public double fL { get; set; }

        [BindProperty]
        public double dist { get; set; }

        [BindProperty]
        public double linearFovW { get; set; }

        public double anamorphFov;

        public double AoV;
        public void OnGet()
        {

        }

        public void OnPost() 
        {
            linearFovW = (senW/fL) * dist;
            anamorphFov = linearFovW * 2;
            AoV = 2 * Math.Atan(senW / ( 2 * fL)) * (180/Math.PI);
        }
    }
}
