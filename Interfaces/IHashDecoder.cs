namespace WebDevHomework.Interfaces
{
    public interface IHashDecoder
    {
        int Decode(string hashedUrl);

        int Adler32(string fullLink);
    }
}