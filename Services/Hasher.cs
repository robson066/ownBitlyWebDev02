using System.Linq;
using HashidsNet;
using WebDevHomework.Interfaces;

namespace WebDevHomework.Services
{
    public class Hasher : IHashDecoder, IHashEncoder
    {
        private readonly Hashids _hashId;
        
        public Hasher()
        {
            _hashId = new Hashids("some random salt", minHashLength : 8);
        }

        public string Encode(int id)
        {
            return _hashId.Encode(id);
        }

        public int Decode(string hashedUrl)
        {
            return _hashId.Decode(hashedUrl).First();
        }

        public int Adler32(string fullLink)
        {
            const int mod = 65521;
            int a = 1, b = 0;
            foreach (char c in fullLink) {
                a = (a + c) % mod;
                b = (b + a) % mod;
            }
            return  (b << 16) | a;
        }  
    }
}