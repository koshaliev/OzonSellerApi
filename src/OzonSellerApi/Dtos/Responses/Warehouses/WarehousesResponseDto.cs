using OzonSellerApi.Enums;
using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Responses.Warehouses;

// created: 24.01.2025
public class WarehousesResponseDto
{
    [JsonPropertyName("result")]
    public List<Warehouse> Result { get; set; } = [];

    public class Warehouse
    {
        /// <summary>
        /// Признак доверительной приёмки. true, если доверительная приёмка включена на складе.
        /// </summary>
        [JsonPropertyName("has_entrusted_acceptance")]
        public bool HasEntrustedAcceptance { get; set; }

        /// <summary>
        /// Признак работы склада по схеме rFBS
        /// </summary>
        [JsonPropertyName("is_rfbs")]
        public bool IsRfbs { get; set; }

        /// <summary>
        /// Название склада.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор склада.
        /// </summary>
        [JsonPropertyName("warehouse_id")]
        public long WarehouseId { get; set; }

        /// <summary>
        /// Возможность печати акта приёма-передачи заранее. true, если печатать заранее возможно.
        /// </summary>
        [JsonPropertyName("can_print_act_in_advance")]
        public bool CanPrintActInAdvance { get; set; }

        /// <summary>
        /// Первая миля FBS.
        /// </summary>
        [JsonPropertyName("first_mile_type")]
        public FirstMileTypeInfo? FirstMileType { get; set; }

        /// <summary>
        /// Признак наличия лимита минимального количества заказов. true, если лимит есть.
        /// </summary>
        [JsonPropertyName("has_postings_limit")]
        public bool HasPostingsLimit { get; set; }

        /// <summary>
        /// Признак, что склад не работает из-за карантина.
        /// </summary>
        [JsonPropertyName("is_karantin")]
        public bool IsKarantin { get; set; }

        /// <summary>
        /// Признак, что склад принимает крупногабаритные товары.
        /// </summary>
        [JsonPropertyName("is_kgt")]
        public bool IsKgt { get; set; }

        /// <summary>
        /// true, если склад работает с эконом-товарами.
        /// </summary>
        [JsonPropertyName("is_economy")]
        public bool IsEconomy { get; set; }

        /// <summary>
        /// Признак, что можно менять расписание работы складов.
        /// </summary>
        [JsonPropertyName("is_timetable_editable")]
        public bool IsTimetableEditable { get; set; }

        /// <summary>
        /// Минимальное значение лимита — количество заказов, которые можно привезти в одной поставке.
        /// </summary>
        [JsonPropertyName("min_postings_limit")]
        public int MinPostingsLimit { get; set; }

        /// <summary>
        /// Значение лимита. -1, если лимита нет.
        /// </summary>
        [JsonPropertyName("postings_limit")]
        public int PostingsLimit { get; set; }

        /// <summary>
        /// Количество рабочих дней склада.
        /// </summary>
        [JsonPropertyName("min_working_days")]
        public long MinWorkingDays { get; set; }

        /// <summary>
        /// Статус склада.
        /// </summary>
        [JsonPropertyName("status")]
        public WarehouseStatus Status { get; set; }

        /// <summary>
        /// Рабочие дни склада.
        /// </summary>
        [JsonPropertyName("working_days")]
        public List<WarehouseWorkingDay> WorkingDays { get; set; } = [];

        /// <summary>
        /// Информация по первой миле FBS.
        /// </summary>
        public class FirstMileTypeInfo
        {
            /// <summary>
            /// Идентификатор DropOff-точки.
            /// </summary>
            [JsonPropertyName("dropoff_point_id")]
            public string DropoffPointId { get; set; } = string.Empty;

            /// <summary>
            /// Идентификатор временного слота для DropOff.
            /// </summary>
            [JsonPropertyName("dropoff_timeslot_id")]
            public long DropoffTimeslotId { get; set; }

            /// <summary>
            /// Признак, что настройки склада обновляются.
            /// </summary>
            [JsonPropertyName("first_mile_is_changing")]
            public bool FirstMileIsChanging { get; set; }

            /// <summary>
            /// Тип первой мили — DropOff или Pickup.
            /// </summary>
            [JsonPropertyName("first_mile_type")]
            public WarehouseFirstMileType FirstMileType { get; set; }
        }
    }
}