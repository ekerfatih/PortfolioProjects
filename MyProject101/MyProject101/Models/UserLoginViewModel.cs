using System;
using System.ComponentModel.DataAnnotations;

namespace MyProject101.Models;

public class UserLoginViewModel {
    [Required(ErrorMessage = "Lütfen kullanıcı adı giriniz")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
