using Microsoft.Extensions.Options;

namespace OzonSellerApi.Extensions;
public class AuthenticationDelegatingHandler : DelegatingHandler
{
    private readonly ApiSettings _apiSettings;
    public AuthenticationDelegatingHandler(IOptions<ApiSettings> apiSettings)
    {
        _apiSettings = apiSettings.Value;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("Client-Id", _apiSettings.ClientId);
        request.Headers.Add("Api-Key", _apiSettings.ApiKey);

        return base.SendAsync(request, cancellationToken);
    }
}
