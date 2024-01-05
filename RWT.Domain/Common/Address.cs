namespace RWT.Domain.Models.Common;
public class Address {
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string StateProvince { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string ZipCode { get; set; } = null!;

    // consts
    public const int StreetMaxLength = 250;
    public const int CityMaxLength = 250;
    public const int StateProvinceMaxLength = 250;
    public const int CountryMaxLength = 250;
    public const int ZipCodeMaxLength = 20;
}