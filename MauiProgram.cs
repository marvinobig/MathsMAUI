using Microsoft.Extensions.Logging;

namespace MathsMAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Math.db");
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.Services
			.AddSingleton(s => ActivatorUtilities.CreateInstance<GameHistory>(s, dbPath));

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
