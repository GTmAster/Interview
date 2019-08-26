using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Matrix
{
    private bool _inFile;
    private BinaryReader _reader;
    private BinaryWriter writer;
    private Stream _stream;
    private double[,] data;

    public Matrix()
    {
        _inFile = false;
        data = new double[1000, 1000];
    }

    public Matrix(string filename)
    {
        _inFile = true;
        _stream = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        _reader = new BinaryReader(_stream);
        writer = new BinaryWriter(_stream);
    }

    public double this[int i, int j] {
        get
        {
            if (_inFile)
            {
                _stream.Seek((1000 * i + j) * sizeof(double), SeekOrigin.Begin);
                return _reader.ReadDouble();
            }
            else return data[i,j];
        }
        set {
            if (_inFile)
            {
                _stream.Seek((1000 * i + j) * sizeof(double), SeekOrigin.Begin);
                writer.Write(value);
            }
            else data[i,j] = value;
        }
    }

    public IEnumerable<double> GetValues(){
        for (int i = 0; i < 1000; i++)
            for (int j = 0; j < 1000; j++)
                yield return this[i,j];
    }

    public void normalize() {
        for (int i = 0; i < 1000; i++)
            for (int j = 0; j < 1000; j++)
                this[i,j] = this[i,j] / GetValues().Sum();
    }
}

