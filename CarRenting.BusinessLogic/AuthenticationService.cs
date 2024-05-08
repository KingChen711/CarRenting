using CarRenting.BusinessLogic.Abstractions;
using CarRenting.Models.Dtos.User;
using CarRenting.Models.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace CarRenting.BusinessLogic;

internal sealed class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private User? _user;

    public AuthenticationService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterUser(UserRegistrationDto userRegistration)
    {
        var user = userRegistration.Adapt<User>();

        var result = await _userManager.CreateAsync(user, userRegistration.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRolesAsync(user, userRegistration.Roles);
        }

        return result;
    }

    public async Task<bool> ValidateUser(UserAuthenticationDto userAuth)
    {
        _user = await _userManager.FindByNameAsync(userAuth.UserName);

        var result = _user != null && await _userManager.CheckPasswordAsync(_user, userAuth.Password);

        return result;
    }

    //public async Task<TokenDto> CreateToken(bool populateExp)
    //{
    //    var signingCredentials = GetSigningCredentials();
    //    var claims = await GetClaims();
    //    var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
    //    var refreshToken = GenerateRefreshToken();

    //    _user!.RefreshToken = refreshToken;

    //    if (populateExp) _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

    //    await _userManager.UpdateAsync(_user);

    //    var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    //    return new TokenDto(accessToken, refreshToken);
    //}

    //public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
    //{
    //    var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
    //    var user = principal.Identity?.Name is not null ? await _userManager.FindByNameAsync(principal.Identity.Name) : null;

    //    if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
    //    {

    //        throw new RefreshTokenBadRequest();
    //    }

    //    _user = user;
    //    return await CreateToken(populateExp: false);
    //}

    //private SigningCredentials GetSigningCredentials()
    //{
    //    var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWTSECRET")!);
    //    var secret = new SymmetricSecurityKey(key);
    //    return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    //}

    //private async Task<List<Claim>> GetClaims()
    //{
    //    var claims = new List<Claim>
    //    {
    //        new(ClaimTypes.Name, _user?.UserName!)
    //    };

    //    var roles = await _userManager.GetRolesAsync(_user!);

    //    foreach (var role in roles)
    //    {
    //        claims.Add(new Claim(ClaimTypes.Role, role));
    //    }

    //    return claims;
    //}

    //private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    //{
    //    var tokenOptions = new JwtSecurityToken
    //    (
    //        issuer: _jwtConfiguration.ValidIssuer,
    //        audience: _jwtConfiguration.ValidAudience,
    //        claims: claims,
    //        expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
    //        signingCredentials: signingCredentials
    //    );
    //    return tokenOptions;
    //}

    //private string GenerateRefreshToken()
    //{
    //    var randomNumber = new byte[32];
    //    using var rng = RandomNumberGenerator.Create();
    //    rng.GetBytes(randomNumber);
    //    return Convert.ToBase64String(randomNumber);
    //}

    //private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    //{
    //    var tokenValidationParameters = new TokenValidationParameters
    //    {
    //        ValidateAudience = true,
    //        ValidateIssuer = true,
    //        ValidateIssuerSigningKey = true,
    //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWTSECRET")!)),
    //        ValidateLifetime = false, //*make the validation still valid if the token expired
    //        ClockSkew = TimeSpan.Zero,
    //        ValidIssuer = _jwtConfiguration.ValidIssuer,
    //        ValidAudience = _jwtConfiguration.ValidAudience
    //    };

    //    var tokenHandler = new JwtSecurityTokenHandler();

    //    var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

    //    var jwtSecurityToken = securityToken as JwtSecurityToken;

    //    if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
    //    {
    //        throw new SecurityTokenException("Invalid token");
    //    }

    //    return principal;
    //}
}