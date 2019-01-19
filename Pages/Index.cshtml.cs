using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace FovCalc.Pages
{
    public class IndexModel : PageModel
    {

        public SelectList frameSizes { get; set; }

       static private Dictionary<string, Camera> cameras = new Dictionary<string, Camera>()
        {
            {"GH5s", new Camera{ name = "GH5s", sensorH = 13, sensorW = 17.3}},
            {"35mm", new Camera{ name = "Super35 Film", sensorH = 24.89, sensorW = 18.66}},
            {"Alexa", new Camera{ name = "Arri Alexa 4:3", sensorH = 23.76, sensorW = 17.82}}
        };

        [BindProperty]
        public double senW { get; set; }

        [BindProperty]
        public double senH { get; set; }

        [BindProperty]
        [Required]
        public string camera { get; set; }

        [BindProperty]
        [Required]
        public double fL { get; set; }

        [BindProperty]
        [Required]
        public double dist { get; set; }

        [BindProperty]
        public double linearFovW { get; set; }

        [BindProperty]
        public bool anamorphic { get; set; }

        [BindProperty]
        public string units { get; set; }

        public double anamorphFov;

        public SelectList cameraOptions = new SelectList
            (
                cameras.Select( x => new { Value = x.Key, Text = x.Value.name}),
                "Value",
                "Text"
            );

        public static List<SelectListItem> unitOption =  new List<SelectListItem>()
        {
            new SelectListItem() {Text="meters", Value="m"},
            new SelectListItem() {Text="feet", Value="\'"}
        };

        public SelectList unitOptions = new SelectList
        (
            unitOption, "Value", "Text"
        );

       // public SelectList unitOptions = new SelectList(unitOption, "Value", "Text");


        public double AoV;
        public void OnGet()
        {

        }

        public void OnPost() 
        {
            if(ModelState.IsValid)
            {
                senH = cameras[camera].sensorH;
                senW = cameras[camera].sensorW;

                linearFovW = (senW/fL) * dist;
                anamorphFov = linearFovW * 2;
                AoV = 2 * Math.Atan(senW / ( 2 * fL)) * (180/Math.PI);
            }
        }
    }
}
