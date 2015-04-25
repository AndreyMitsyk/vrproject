namespace VRA.Dto
{
    public class CustomerDto
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  e-mail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///  Код города
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Регион( штат, область и тп)
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string ZipPostalCode { get; set; }

        /// <summary>
        /// Страна
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Номер дома
        /// </summary>
        public string HouseNumber { get; set; }
    }
}
