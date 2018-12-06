using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using FluentValidation.Attributes;

namespace Site.Models
{
    [Validator(typeof(FooModelValidator))]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Тип груза")]
        //[Required(ErrorMessage = "Выберите тип груза")]
        public string Type { get; set; }

        [Display(Name ="Масса")]
        [Range(0,20000)]
        //[Required(ErrorMessage = "Введите массу груза")]
        public int Mass { get; set; }

        [Display(Name ="Откуда")]
        //[Required(ErrorMessage = "Введите пункт отправления")]
        public string From { get; set; }

        [Display(Name ="Куда")]
        //[Required(ErrorMessage = "Введите пункт назначения")]
        public string To { get; set; }

        [Display(Name ="Дата отправки")]
        //[Required(ErrorMessage = "Выберите дату отправки")]
        public string Date { get; set; }

        [ForeignKey("DriverRef")]
        public int DriverId { get; set; }
        public virtual Driver DriverRef { get; set; }

    }

    public class FooModelValidator : AbstractValidator<Order>
    {
        public FooModelValidator()
        {
            RuleFor(x => x.Type).NotEmpty().Equal(x=> "-- Please select a category --").WithMessage("Введите тип груза");
            RuleFor(x => x.Mass).NotEmpty().WithMessage("Введите массу груза");
            RuleFor(x => x.From).NotEmpty().WithMessage("Введите пункт отправления");
            RuleFor(x => x.To).NotEmpty().WithMessage("Введите пункт назначения");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Введите дату отправления");


        }
    }
}
