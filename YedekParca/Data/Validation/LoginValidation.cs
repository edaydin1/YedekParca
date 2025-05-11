using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Mapping;

namespace Data.Validation
{
    public class LoginValidation : AbstractValidator<LoginRequestDTO>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Username)
                 .NotEmpty().WithMessage("Kullanıcı adı boş olamaz!")
                 .MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalı!");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş olamaz!")
                .MinimumLength(3).WithMessage("Şifre en az 3 karakter olmalı!");
        }
    }
}
