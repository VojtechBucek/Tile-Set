using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileSetPoPrasacku
{
    class Mapa : IDisposable
    {
        public Mapa(string[,] tiles)
        {
            int columns = tiles.GetLength(0);
            int rows = tiles.GetLength(1);
            map = new System.Drawing.Bitmap[columns,rows];
            for(int x=0; x<columns; ++x)
            {
                for(int y=0; y<rows; ++y)
                {
                    string path = $"Tiles\\{tiles[x, y]}.png";
                    Bitmap bmp = new Bitmap(path);
                    map[x, y] = bmp;
                }
            }
        }
        public Bitmap GetTile(int x, int y)
        {
            return map[x, y];
        }

        public int tileWidth => GetTile(0, 0).Width;
        public int tileHeight => GetTile(0, 0).Height;

        public Bitmap GetMap(int x, int y, int xNum, int yNum)
        {
            Bitmap ret = new Bitmap(tileWidth * xNum, tileHeight * yNum);
            Graphics g = Graphics.FromImage(ret);
            for(int i=0; i<xNum; ++i)
            {
                for(int j=0; j<yNum; ++j)
                {
                    int posY = i * tileWidth;
                    int posX = j * tileHeight;
                    g.DrawImage(GetTile(x+i, y+j), posX, posY);
                }
            }
            return ret;
        }

        public void Dispose()
        {
        }

        private Bitmap[,] map;
    }
}
