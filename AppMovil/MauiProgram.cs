using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace AppMovil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
				.ConfigureMauiHandlers(handlers =>
				{
#if ANDROID
					// Remueve el subrayado/underline (background nativo) de los EditText usados por Entry
					handlers.AddHandler(typeof(Entry), typeof(Microsoft.Maui.Handlers.EntryHandler));
					Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
					{
						if (h.PlatformView is Android.Widget.EditText editText)
						{
							// Quita el fondo nativo que genera la línea
							editText.Background = null;
						}
					});
#endif
				})
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
