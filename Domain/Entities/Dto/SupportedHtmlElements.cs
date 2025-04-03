using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Dto
{
    public enum SupportedHtmlElements
    {
        //Addding a default, shouldn't be used
        NotProvided,

        Checkbox,
        Radio,
        Select,
        Textarea,
        Text, //To match the db
              //All the following types are muted TextBoxes
        Number,
        Email,
        Password,
        Date,

        Invalid //added to handle parse errors
    }

}
