namespace Domain.Shared;

public static class MetodosComuns
{
    public static bool NotContainAccentedCharacters(string email)
    {
        // Verifique se o email não contém letras acentuadas
        foreach (char c in email)
        {
            if ("áàâãéèêíïóôõúüç=[]\\;',/~!#$%^&*()_+{}|:\"<>?¡!¿?ºª`¬´çÇ\r\náéíóúüñÁÉÍÓÚÜÑ".Contains(c.ToString()))
            {
                return false;
            }
        }

        if (email.Contains(" ") || email.Contains(".."))
            return false;


        return true;
    }
}
