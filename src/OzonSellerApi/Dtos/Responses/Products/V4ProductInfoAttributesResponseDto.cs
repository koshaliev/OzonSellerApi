using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Responses.Products;

// created: 13.02.2025
public class V4ProductInfoAttributesResponseDto
{
    /// <summary>
    /// Результаты запроса.
    /// </summary>
    public List<Item> Result { get; set; } = [];

    /// <summary>
    /// Идентификатор последнего значения на странице. Оставьте это поле пустым при выполнении первого запроса.
    /// <para>Чтобы получить следующие значения, укажите <see cref="LastId"/> из ответа предыдущего запроса.</para>
    /// </summary>
    [JsonPropertyName("last_id")]
    public string LastId { get; set; } = string.Empty;

    /// <summary>
    /// Количество товаров в списке.
    /// </summary>
    public long Total { get; set; }


    public class Item
    {
        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Штрихкод.
        /// </summary>
        [JsonPropertyName("barcode")]
        public string Barcode { get; set; } = string.Empty;

        /// <summary>
        /// Название товара.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор товара в системе продавца — артикул.
        /// </summary>
        [JsonPropertyName("offer_id")]
        public string OfferId { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор типа товара.
        /// </summary>
        [JsonPropertyName("type_id")]
        public long TypeId { get; set; }

        /// <summary>
        /// Высота упаковки.
        /// </summary>
        [JsonPropertyName("height")]
        public long Height { get; set; }

        /// <summary>
        /// Глубина.
        /// </summary>
        [JsonPropertyName("depth")]
        public long Depth { get; set; }

        /// <summary>
        /// Ширина упаковки.
        /// </summary>
        [JsonPropertyName("width")]
        public long Width { get; set; }

        /// <summary>
        /// Единица измерения габаритов:
        /// <list type="bullet">
        /// <item>mm — миллиметры, </item>
        /// <item>cm — сантиметры, </item>
        /// <item>in — дюймы.</item>
        /// </list>
        /// </summary>
        [JsonPropertyName("dimension_unit")]
        public string DimensionUnit { get; set; } = string.Empty;

        /// <summary>
        /// Вес товара в упаковке.
        /// </summary>
        [JsonPropertyName("weight")]
        public long Weight { get; set; }

        /// <summary>
        /// Единица измерения веса.
        /// </summary>
        [JsonPropertyName("weight_unit")]
        public string WeightUnit { get; set; } = string.Empty;

        /// <summary>
        /// Ссылка на главное изображение товара.
        /// </summary>
        [JsonPropertyName("primary_image")]
        public string PrimaryImage { get; set; } = string.Empty;

        /// <summary>
        /// Информация о модели.
        /// </summary>
        [JsonPropertyName("model_info")]
        public ModelInfo? ModelInfo { get; set; }

        /// <summary>
        /// Массив ссылок на изображения товара. Порядок изображений аналогичен порядку в карточке товаров.
        /// </summary>
        [JsonPropertyName("images")]
        public List<string> Images { get; set; } = [];

        /// <summary>
        /// Массив PDF-файлов.
        /// </summary>
        [JsonPropertyName("pdf_list")]
        public List<PdfFile> PdfList { get; set; } = [];

        /// <summary>
        /// Массив характеристик товара.
        /// </summary>
        [JsonPropertyName("attributes")]
        public List<AttributeItem> Attributes { get; set; } = [];

        /// <summary>
        /// Массив вложенных характеристик.
        /// </summary>
        [JsonPropertyName("complex_attributes")]
        public List<ComplexAttributeItem> ComplexAttributes { get; set; } = [];

        /// <summary>
        /// Маркетинговый цвет.
        /// </summary>
        [JsonPropertyName("color_image")]
        public string ColorImage { get; set; } = string.Empty;

        // TODO: сделать методы /v1/description-category/attribute и /v1/description-category/attribute/values.
        /// <summary>
        /// Идентификатор категории. Используйте его с методами /v1/description-category/attribute и /v1/description-category/attribute/values.
        /// </summary>
        [JsonPropertyName("description_category_id")]
        public long DescriptionCategoryId { get; set; }
    }

    /// <summary>
    /// Информация о модели.
    /// </summary>
    public class ModelInfo
    {
        /// <summary>
        /// Идентификатор модели.
        /// </summary>
        [JsonPropertyName("model_id")]
        public long ModelId { get; set; }

        /// <summary>
        /// Количество объединённых товаров модели.
        /// </summary>
        [JsonPropertyName("count")]
        public long Count { get; set; }
    }

    public class AttributeItem
    {
        /// <summary>
        /// Идентификатор характеристики.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор характеристики, которая поддерживает вложенные свойства. Например, у характеристики «Процессор» есть вложенные характеристики «Производитель» и «L2 Cache». У каждой из вложенных характеристик может быть несколько вариантов значений.
        /// </summary>
        [JsonPropertyName("complex_id")]
        public long ComplexId { get; set; }

        /// <summary>
        /// Массив значений характеристик.
        /// </summary>
        [JsonPropertyName("values")]
        public List<ValueItem> Values { get; set; } = [];

        /// <summary>
        /// Значение характеристики.
        /// </summary>
        public class ValueItem
        {
            /// <summary>
            /// Идентификатор характеристики в словаре.
            /// </summary>
            [JsonPropertyName("dictionary_value_id")]
            public long DictionaryValueId { get; set; }

            /// <summary>
            /// Значение характеристики товара.
            /// </summary>
            [JsonPropertyName("value")]
            public string Value { get; set; } = string.Empty;
        }
    }

    public class PdfFile
    {
        /// <summary>
        /// Путь к PDF-файлу.
        /// </summary>
        [JsonPropertyName("file_name")]
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// Название файла.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }

    public class ComplexAttributeItem
    {
        /// <summary>
        /// Идентификатор характеристики.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор характеристики, которая поддерживает вложенные свойства. Например, у характеристики «Процессор» есть вложенные характеристики «Производитель» и «L2 Cache». У каждой из вложенных характеристик может быть несколько вариантов значений.
        /// </summary>
        [JsonPropertyName("complex_id")]
        public long ComplexId { get; set; }

        /// <summary>
        /// Массив значений характеристик.
        /// </summary>
        [JsonPropertyName("values")]
        public List<ValueItem> Values { get; set; } = [];

        /// <summary>
        /// Значение характеристики.
        /// </summary>
        public class ValueItem
        {
            /// <summary>
            /// Идентификатор характеристики в словаре.
            /// </summary>
            [JsonPropertyName("dictionary_value_id")]
            public long DictionaryValueId { get; set; }

            /// <summary>
            /// Значение характеристики товара.
            /// </summary>
            [JsonPropertyName("value")]
            public string Value { get; set; } = string.Empty;
        }
    }
}
