using Microsoft.AspNetCore.Mvc.Filters;
using DefaultValueInjection;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using DefaultValueInjection.Model;
using System.Linq;

namespace DefaultValueInjection.Filters
{
    public class DefaultUserPreferenceSettingsFilter : ActionFilterAttribute
    {
        readonly DefaultSettings _defaultSettings;

        public DefaultUserPreferenceSettingsFilter(IOptions<DefaultSettings> defaultSettings)
        {
            _defaultSettings = defaultSettings.Value;
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var request = context.ActionArguments.Values.OfType<UserProfile>().FirstOrDefault();
            if (request != null)
            {
                var preference = request.Preference;

                if (preference != null)
                {
                    //check the request contains the preference values if not substitute the default values from default settings
                    if (string.IsNullOrEmpty(preference.Language)) preference.Language = _defaultSettings.Language;
                    if (string.IsNullOrEmpty(preference.Theme)) preference.Theme = _defaultSettings.Theme;
                }
                else
                {
                    request.Preference = new Preference { Language = _defaultSettings.Language, Theme = _defaultSettings.Theme };
                }
            }

            return base.OnActionExecutionAsync(context, next);
        }
    }
}
