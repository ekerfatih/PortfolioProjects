using System;
using System.ComponentModel.DataAnnotations;

namespace MyProject101.Models;

public class UserEditViewModel {

    [Required(ErrorMessage = "Lütfen İsim giriniz")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Lütfen Soyisim giriniz")]
    public string SurName { get; set; }
    [Required(ErrorMessage = "Lütfen cinsiyet seçiniz")]

    public string Gender { get; set; }
    [Required(ErrorMessage = "Lütfen Email adresinizi giriniz")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Lütfen Şifre Tekrarı Giriniz")]
    [Compare(nameof(Password), ErrorMessage = "Lütfen şifrenin eşleştiğinden emin olun.")]
    public string ConfirmPassword { get; set; }
}
