public static class ErrorHandler
{
    public static void HandleError(string mess, Exception ex)
    {
        Helper.WriteMessageAndWait(mess + " Press enter to continue.");
        Log.Error(ex.Message);
    }
}