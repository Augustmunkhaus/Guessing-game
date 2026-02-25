using Microsoft.JSInterop;

namespace Metaldle.BlazorWASM.Services;

public class SessionService
{
    // injecting JS runtime to use JS functions and make calls to the browser
    private readonly IJSRuntime _js;

    public SessionService(IJSRuntime js)
    {
        _js = js;
    }
    public async Task<string> GetOrCreateSessionIdAsync()
    { // Ask the browser to look up our session ID in localStorage
        var existingId = await _js.InvokeAsync<string?>("localStorage.getItem", "sessionId");

        if (existingId != null)
        {
            return existingId;
        }
        
        //if no Guid exists, create a new and save it to localstorage 
        
        var newGuid = Guid.NewGuid().ToString();
        
        await _js.InvokeVoidAsync("localStorage.setItem", "sessionId", newGuid);
        
        return newGuid;
    }
}