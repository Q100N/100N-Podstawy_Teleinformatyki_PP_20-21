using System;
namespace DietaApp.Core
{
    public class BaseEntityDto
    {
        // Osobno Id, żeby nie powielać metod w BaseRepository
        public int Id { get; set; }
    }
}