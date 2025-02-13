﻿# 📚 OzonSellerApi

Библиотека для взаимодействия с **Ozon Seller API**.

## 🧩 Зависимости
- [FluentResults](https://github.com/altmann/FluentResults) — для удобства работы с результатами операций и обработкой ошибок.

## ✅ Уже реализовано
Клиенты для частичного взаимодействия с Товарами, Ценами, Остатками, Складами и Отправлениями.
- ProductClient: список товаров, список товаров с информацией по каждой позиции, описание характеристик товара;
- PriceClient: информация о ценах и обновление цен;
- StockClient: обновление остатков товаров на складах, получение информации об остатках (сколько в наличии и сколько зарезервировано покупателями);
- WarehouseClient: список складов и список методов доставки склада;
- PostingClient: список необработанных FBS заказов за период.

## 🎯 Задачи
- Клиент для работы с Аналитическими отчетами;
- PostingClient: реализовать методы для обработки заказов (сборка, маркировка, список заказов на отгрузку и т.д.).