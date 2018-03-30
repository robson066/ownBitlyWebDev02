using WebDevHomework.Interfaces;

namespace WebDevHomework.Services
{
    public class Decoder : IHashDecoder
    {
        private readonly Hasher _hasher;

        public Decoder(Hasher hasher)
        {
            _hasher = hasher;
        }

        public int Adler32(string fullLink)
        {
            return _hasher.Adler32(fullLink);
        }  

        public int Decode(string hashedUrl)
        {
            return _hasher.Decode(hashedUrl);
        }
    }
}