using System.ComponentModel.DataAnnotations;

namespace webtemplate.Models;
//validate
public class Student
{
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "Bạn phải nhập tên")]
    [StringLength(100, MinimumLength = 4, ErrorMessage = "Bạn phải nhập tên có độ dài từ 4-100 kí tự") ]
    public string? Name { get; set; }
    [Required(ErrorMessage ="Bạn phải nhập email")]
    [RegularExpression(@"^[\w-]+(\.[\w-]+)*@gmail\.com$",
    ErrorMessage = "Bạn phải nhập email có đuôi là gmail.com")]
    public string? Email { get; set; }
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$",
    ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên, có ít nhất một chữ cái viết hoa, một chữ cái viết thường, một chữ số và một ký tự đặc biệt.")]
    [Required(ErrorMessage = "Bạn phải nhập password")]
    public string? Password { get; set; }
    [Required(ErrorMessage = "Bạn phải nhập Branch")]
    public Branch? Branch { get; set; }
    [Required(ErrorMessage = "Bạn phải nhập giới tính")]
    public Gender? Gender { get; set; }
    public bool IsRegular { get; set; }
    [DataType(DataType.MultilineText)]
    [Required(ErrorMessage = "Bạn phải nhập Bạn phải nhập địa chỉ")]
    public string? Address { get; set; }
    [Range(typeof(DateTime), "1/1/1963", "12/31/2023", ErrorMessage = "Ngày sinh phải nằm trong khoảng từ 01/01/1963 đến 31/12/2023")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Bạn phải nhập ngày sinh")]
    public DateTime DateOfBorth { get; set; }
    [Range(typeof(double),"0.0","10.0",ErrorMessage ="Bạn phải nhập điểm trong khoảng 0.0- 10.0")]
    // đùng data type
    [Required (ErrorMessage ="Bạn phải nhập điểm")]
    public double? Diem { get ; set;}
}
