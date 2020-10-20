using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.PostNewQuestionWorkflow
{
    
    public struct NewQuestioncmd
    {
        [Required]
        public string Title { get; private set; }           //titlu
        [Required]
        
        public string Body { get; private set; }            //continutul intrebarii
        
        public string Tags { get; set; }                     //tagurile intrebarii
        public NewQuestioncmd(string title, string body, string tags)
        {
            Title = title;
            Body = body;
            
            Tags = tags;
            
        }
    }
}
