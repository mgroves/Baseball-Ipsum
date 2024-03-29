﻿using System.ComponentModel.DataAnnotations;

namespace BaseballIpsum.Web.Models;

public class SubmitFormViewModel
{
    [Required]
    [Display(Name = "Paragraphs:")]
    [Range(1,25,ErrorMessage = "1 paragraph minimum, 25 paragraph maximum")]
    public int NumParagraphs { get; set; }

    [Display(Name = "Start with 'Baseball ipsum dolor sit amet...'")]
    public bool StartWithBaseballIpsum { get; set; }

    public List<string>? GeneratedParagraphs { get; set; }
}