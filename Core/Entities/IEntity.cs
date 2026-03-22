using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Core katmanı diğer sınıfları referans almaz.
//entities altındaki abstract klasöründki entities cs sini de buraya taşıdıık. Core bizim evrensel katmanımız.
namespace Core.Entities
{
    //IEntity implemente eden class bir veritabanı tablosudur.
    public interface IEntity
    {

    }
}
