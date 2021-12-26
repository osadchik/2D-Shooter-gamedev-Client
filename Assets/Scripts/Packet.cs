using System.Collections.Generic;

namespace Assets.Scripts
{
    public class Packet
    {
        private List<byte> buffer;
        private byte[] readableBuffer;
        private int readPos;

        public Packet()
        {
            buffer = new List<byte>();
            readPos = 0;
        }

        public Packet(int id)
        {
            buffer = new List<byte>();
            readPos = 0;

            Write(id);
        }


    }
}
