﻿-- Cities --

-- Москва
-- Санкт-Петербург
-- Минск
-- Екатеринбург
-- Новосибирск
-- Самара
-- Ростов-на-Дону
-- Нижний Новгород
-- Челябинск

SET IDENTITY_INSERT dbo.City ON
INSERT INTO dbo.City (Id, Name, InternalName)
     VALUES 
        (3, N'Минск', N'mns'),
        (4, N'Екатеринбург', N'ekb'),
        (5, N'Новосибирск', N'nvs'),
        (6, N'Самара', N'sam'),
        (7, N'Ростов-на-Дону', N'rnd'),
        (8, N'Нижний Новгород', N'nng'),
        (9, N'Челябинск', N'che')
SET IDENTITY_INSERT dbo.City OFF
GO

-- CityId
-- 1	     Санкт-Петербург
-- 2	     Москва
-- 3	     Минск
-- 4	     Екатеринбург
-- 5	     Новосибирск
-- 6	     Самара
-- 7	     Ростов-на-Дону
-- 8	     Нижний Новгород
-- 9	     Челябинск

INSERT INTO [dbo].[CitySeoParameter]
           ([Value]
           ,[Alias]
           ,[CityId])
     VALUES
	(N'Санкт Петербург', N'spb', 1),
	(N'СПб', N'spb-abbr', 1),
	(N'Питер', N'Piter', 1),

	(N'Москва', N'msk', 2),
	(N'мск', N'msk-abbr', 2),
	(N'моск', N'mosk', 2),

	(N'Минск', N'mns', 3),

	(N'Екатеринбург', N'ekb', 4),
	(N'екб', N'ekb-abbr', 4),

	(N'Новосибирск', N'nvs', 5),
	(N'в Новосибе', N'v-Novosibe', 5),
	
	(N'Самара', N'sam', 6),
  
	(N'Ростов на Дону', N'rnd', 7),
	(N'в Ростове на Дону', N'v-Rostove-na-Donu', 7),
	(N'Ростов', N'Rostov', 7),

	(N'Нижний Новгород', N'nng', 8),
	(N'в Нижнем', N'v-Nizhnem', 8),
	(N'в Новгороде', N'v-Novgorode', 8),

	(N'Челябинск', N'che', 9)
GO

SET IDENTITY_INSERT [dbo].[District] ON

INSERT INTO [dbo].[District]
           (Id
           ,[Name]
           ,[CityId])
     VALUES
-- spb, 1
(1, N'Адмиралтейский', 1),
(2, N'Василеостровский', 1),
(3, N'Выборгский', 1),
(4, N'Калининский', 1),
(5, N'Кировский', 1),
(6, N'Колпинский', 1),
(7, N'Красногвардейский', 1),
(8, N'Красносельский', 1),
(9, N'Кронштадтский', 1),
(10, N'Курортный', 1),
(11, N'Московский', 1),
(12, N'Невский', 1),
(13, N'Область', 1),
(14, N'Петроградский', 1),
(15, N'Петродворцовый', 1),
(16, N'Приморский', 1),
(17, N'Пушкинский', 1),
(18, N'Фрунзенский', 1),
(19, N'Центральный', 1),

-- msk
(20	, N'Академический', 2),
(21	, N'Алексеевский', 2),
(22	, N'Алтуфьевский', 2),
(23	, N'Арбат', 2),
(24	, N'Аэропорт', 2),
(25	, N'Бабушкинский', 2),
(26	, N'Басманный', 2),
(27	, N'Беговой', 2),
(28	, N'Бескудниковский', 2),
(29	, N'Бибирево', 2),
(30	, N'Бирюлёво Восточное', 2),
(31	, N'Бирюлёво Западное', 2),
(32	, N'Богородское', 2),
(33	, N'Братеево', 2),
(34	, N'Бутово Северное', 2),
(35	, N'Бутово Южное', 2),
(36	, N'Бутырский', 2),
(37	, N'Вешняки', 2),
(38	, N'Внуково', 2),
(39	, N'Войковский', 2),
(40	, N'Восточный', 2),
(41	, N'Выхино-Жулебино', 2),
(42	, N'Гагаринский', 2),
(43	, N'Головинский', 2),
(44	, N'Гольяново', 2),
(45	, N'Даниловский', 2),
(46	, N'Дегунино Восточное', 2),
(47	, N'Дегунино Западное', 2),
(48	, N'Дмитровский', 2),
(49	, N'Донской', 2),
(50	, N'Дорогомилово', 2),
(51	, N'Замоскворечье', 2),
(52	, N'Зюзино', 2),
(53	, N'Зябликово', 2),
(54	, N'Ивановское', 2),
(55	, N'Измайлово Восточное', 2),
(56	, N'Измайлово', 2),
(57	, N'Измайлово Северное', 2),
(58	, N'Капотня', 2),
(59	, N'Коньково', 2),
(60	, N'Коптево', 2),
(61	, N'Косино-Ухтомский', 2),
(62	, N'Котловка', 2),
(63	, N'Красносельский', 2),
(64	, N'Крылатское', 2),
(65	, N'Крюково', 2),
(66	, N'Кузьминки', 2),
(67	, N'Кунцево', 2),
(68	, N'Куркино,', 2),
(69	, N'Левобережный', 2),
(70	, N'Лефортово', 2),
(71	, N'Лианозово', 2),
(72	, N'Ломоносовский', 2),
(73	, N'Лосиноостровский', 2),
(74	, N'Люблино', 2),
(75	, N'Марфино', 2),
(76	, N'Марьина роща', 2),
(77	, N'Марьино', 2),
(78	, N'Матушкино', 2),
(79	, N'Медведково Северное', 2),
(80	, N'Медведково Южное', 2),
(81	, N'Метрогородок', 2),
(82	, N'Мещанский', 2),
(83	, N'Митино', 2),
(84	, N'Можайский', 2),
(85	, N'Молжаниновский', 2),
(86	, N'Москворечье-Сабурово', 2),
(87	, N'Нагатино-Садовники', 2),
(88	, N'Нагатинский затон', 2),
(89	, N'Нагорный', 2),
(90	, N'Некрасовка', 2),
(91	, N'Нижегородский', 2),
(92	, N'Ново-Переделкино', 2),
(93	, N'Новогиреево', 2),
(94	, N'Новокосино', 2),
(95	, N'Обручевский', 2),
(96	, N'Орехово-Борисово Северное', 2),
(97	, N'Орехово-Борисово Южное', 2),
(98	, N'Останкинский', 2),
(99	, N'Отрадное', 2),
(100	, N'Очаково-Матвеевское', 2),
(101	, N'Перово', 2),
(102	, N'Печатники', 2),
(103	, N'Покровское-Стрешнево', 2),
(104	, N'Преображенское', 2),
(105	, N'Пресненский', 2),
(106	, N'Проспект Вернадского', 2),
(107	, N'Раменки', 2),
(108	, N'Ростокино', 2),
(109	, N'Рязанский', 2),
(110	, N'Савёлки', 2),
(111	, N'Савёловский', 2),
(112	, N'Свиблово', 2),
(113	, N'Северный', 2),
(114	, N'Силино', 2),
(115	, N'Сокол', 2),
(116	, N'Соколиная гора', 2),
(117	, N'Сокольники', 2),
(118	, N'Солнцево', 2),
(119	, N'Старое Крюково', 2),
(120	, N'Строгино', 2),
(121	, N'Таганский', 2),
(122	, N'Тверской', 2),
(123	, N'Текстильщики', 2),
(124	, N'Тёплый Стан', 2),
(125	, N'Тимирязевский', 2),
(126	, N'Тропарёво-Никулино', 2),
(127	, N'Тушино Северное', 2),
(128	, N'Тушино Южное', 2),
(129	, N'Филёвский парк', 2),
(130	, N'Фили-Давыдково', 2),
(131	, N'Хамовники', 2),
(132	, N'Ховрино', 2),
(133	, N'Хорошёво-Мневники', 2),
(134	, N'Хорошёвский', 2),
(135	, N'Царицыно', 2),
(136	, N'Черёмушки', 2),
(137	, N'Чертаново Северное', 2),
(138	, N'Чертаново Центральное', 2),
(139	, N'Чертаново Южное', 2),
(140	, N'Щукино', 2),
(141	, N'Южнопортовый', 2),
(142	, N'Якиманка', 2),
(143	, N'Ярославский', 2),
(144	, N'Ясенево', 2),
	
-- mns, 3
(145,	N'Заводской', 3),
(146,	N'Ленинский', 3),
(147,	N'Московский', 3),
(148,	N'Октябрьский', 3),
(149,	N'Партизанский', 3),
(150,	N'Первомайский', 3),
(151,	N'Советский', 3),
(152,	N'Фрунзенский', 3),
(153,	N'Центральный', 3),
(154,	N'Академгородок', 3),
(155,	N'Академия наук', 3),
(156,	N'Ангарская', 3),
(157,	N'Аэродромная', 3),
(158,	N'Боровляны', 3),
(159,	N'Восток', 3),
(160,	N'Восточный', 3),
(161,	N'Ждановичи', 3),
(162,	N'Заславская', 3),
(163,	N'Зеленый луг', 3),
(164,	N'Красный Бор', 3),
(165,	N'Курасовщина', 3),
(166,	N'Лошица', 3),
(167,	N'Малиновка', 3),
(168,	N'Минск-Сити', 3),
(169,	N'Петровщина', 3),
(170,	N'Серебрянка', 3),
(171,	N'Серова', 3),
(172,	N'Сосны', 3),
(173,	N'Сухарево', 3),
(174,	N'Уручье', 3),
(175,	N'Филиал БГУ', 3),
(176,	N'Харьковская', 3),
(177,	N'Цна', 3),
(178,	N'Цнянка', 3),
(179,	N'Чижовка', 3),
(180,	N'Шабаны', 3),
(181,	N'Юго-Запад', 3),
	
-- ekb, 4
(182,	N'Верх-Исетский', 4),
(183,	N'Широкая Речка', 4),
(184,	N'Гора Хрустальная', 4),
(185,	N'Лиственный', 4),
(186,	N'Перегон', 4),
(187,	N'Светлая Речка', 4),
(188,	N'Академический', 4),
(189,	N'ВИЗ', 4),
(190,	N'Заречный', 4),
(191,	N'Железнодорожный', 4),
(192,	N'Вокзальный', 4),
(193,	N'Горнозаводский', 4),
(194,	N'Палкино', 4),
(195,	N'Семь Ключей', 4),
(196,	N'Старая Сортировка', 4),
(197,	N'Новая Сортировка', 4),
(198,	N'Северный промышленный', 4),
(199,	N'Сортировочный (Сортировка)', 4),
(200,	N'Кировский', 4),
(201,	N'ВТУЗгородок', 4),
(202,	N'Изоплит', 4),
(203,	N'Калиновский', 4),
(204,	N'Комсомольский (ЖБИ)', 4),
(205,	N'Пионерский', 4),
(206,	N'Центральный (Центр)', 4),
(207,	N'Шарташ (Шарташский)', 4),
(208,	N'Ленинский', 4),
(209,	N'Юго-Западный', 4),
(210,	N'Московская горка', 4),
(211,	N'УНЦ (Краснолесье)', 4),
(213,	N'Октябрьский', 4),
(214,	N'Кольцово', 4),
(215,	N'Компрессорный', 4),
(216,	N'Малый Исток', 4),
(217,	N'Парковый', 4),
(218,	N'Сибирский', 4),
(219,	N'Синие Камни', 4),
(220,	N'Глубокое', 4),
(221,	N'Мостовка', 4),
(223,	N'Лечебный (Чапаевский)', 4),
(224,	N'Птицефабрика', 4),
(225,	N'Орджоникидзевский', 4),
(227,	N'Уралмаш', 4),
(228,	N'Эльмаш', 4),
(229,	N'Козловский', 4),
(230,	N'Аппаратный', 4),
(231,	N'Ягодный', 4),
(232,	N'Чкаловский', 4),
(233,	N'Ботанический', 4),
(234,	N'Вторчермет', 4),
(235,	N'Елизавет', 4),
(236,	N'Нижне-Исетский (Нижне-Исетск)', 4),
(237,	N'Рудный', 4),
(238,	N'Уктусский (Уктус)', 4),
(239,	N'Химмаш', 4),
(240,	N'Южный (Автовокзал)', 4),
(241,	N'Приисковый', 4),
(242,	N'Хутор', 4),
	
-- nvs, 5
(243,	N'Дзержинский', 5),
(244,	N'Железнодорожный', 5),
(245,	N'Заельцовский', 5),
(246,	N'Калининский', 5),
(247,	N'Кировский', 5),
(248,	N'Ленинский', 5),
(249,	N'Октябрьский', 5),
(250,	N'Первомайский', 5),
(251,	N'Советский', 5),
(252,	N'Центральный', 5),
	
-- sam' 6
(253,	N'Железнодорожный', 6),
(254,	N'Кировский', 6),
(255,	N'Красноглинский', 6),
(256,	N'Куйбышевский', 6),
(257,	N'Ленинский', 6),
(258,	N'Октябрьский', 6),
(259,	N'Промышленный', 6),
(260,	N'Самарский', 6),
(261,	N'Советский', 6),

-- rnd, 7
(262,	N'Ворошиловский', 7),
(263,	N'Железнодорожный', 7),
(264,	N'Кировский', 7),
(265,	N'Ленинский', 7),
(266,	N'Октябрьский', 7),
(267,	N'Первомайский', 7),
(268,	N'Пролетарский', 7),
(269,	N'Советский', 7),
(270,	N'1-й п. Орджоникидзе', 7),
(271,	N'2-й п. Орджоникидзе', 7),
(272,	N'Александровка', 7),
(273,	N'Берберовка', 7),
(274,	N'Болгарстрой', 7),
(275,	N'Верхнетемерницкий', 7),
(276,	N'Военвед', 7),
(277,	N'ЗЖМ', 7),
(278,	N'Змиевка', 7),
(279,	N'Каменка', 7),
(280,	N'Кирпичный', 7),
(281,	N'Левенцовский', 7),
(282,	N'Ленгородок', 7),
(283,	N'Мирный', 7),
(284,	N'Мясникован', 7),
(285,	N'Нахичевань', 7),
(286,	N'Новое поселение', 7),
(287,	N'Олимпиадовка', 7),
(288,	N'Рабочий городок', 7),
(289,	N'Сельмаш', 7),
(290,	N'СЖМ', 7),
(291,	N'Стройгородок', 7),
(292,	N'Суворовский', 7),
(293,	N'Темерник', 7),
(294,	N'Фрунзе', 7),
(295,	N'Чкаловский', 7),

-- nng, 8
(296,	N'Автозаводский', 8),
(297,	N'Канавинский', 8),
(298,	N'Ленинский', 8),
(299,	N'Московский', 8),
(300,	N'Нижегородский', 8),
(301,	N'Приокский', 8),
(302,	N'Советский', 8),
(303,	N'Сормовский', 8),
	
-- che, 9
(304,	N'Центральный', 9), -- центр, тополиная алея
(305,	N'Тракторозаводской', 9), -- чтз, северо-восток
(306,	N'Советский', 9), -- амз, областная больница
(307,	N'Ленинский', 9), -- ленинский
(308,	N'Металлургический', 9), -- чмз
(309,	N'Калининский', 9), -- северо-запад
(310,	N'Курчатовский', 9) -- северо-запад


SET IDENTITY_INSERT [dbo].[District] OFF
GO

INSERT INTO dbo.DistrictSeoParameter
           (
           DistrictId,
           Value,
           CityId,
           Alias
           )
     VALUES

-- spb, 1
(1, N'Адмиралтейский', 1, N'Admiraltejskij'),
(2, N'Василеостровский', 1, N'Vasileostrovskij'),
(3, N'Выборгский', 1, N'Vyborgskij'),
(4, N'Калининский', 1, N'Kalininskij'),
(5, N'Кировский', 1, N'Kirovskij'),
(6, N'Колпинский', 1, N'Kolpinskij'),
(7, N'Красногвардейский', 1, N'Krasnogvardejskij'),
(8, N'Красносельский', 1, N'Krasnoselskij'),
(9, N'Кронштадтский', 1, N'Kronshtadtskij'),
(10, N'Курортный', 1, N'Kurortnyj'),
(11, N'Московский', 1, N'Moskovskij'),
(12, N'Невский', 1, N'Nevskij'),
(13, N'Область', 1, N'Oblast'),
(14, N'Петроградский', 1, N'Petrogradskij'),
(15, N'Петродворцовый', 1, N'Petrodvorcovyj'),
(16, N'Приморский', 1, N'Primorskij'),
(17, N'Пушкинский', 1, N'Pushkinskij'),
(18, N'Фрунзенский', 1, N'Frunzenskij'),
(19, N'Центральный', 1, N'Centralnyj'),

-- msk, 2
(20	, 'Академический', 2, N'Akademicheskij'),
(21	, 'Алексеевский', 2, N'Alekseevskij'),
(22	, 'Алтуфьевский', 2, N'Altufevskij'),
(23	, 'Арбат', 2, N'Arbat'),
(24	, 'Аэропорт', 2, N'Aehroport'),
(25	, 'Бабушкинский', 2, N'Babushkinskij'),
(26	, 'Басманный', 2, N'Basmannyj'),
(27	, 'Беговой', 2, N'Begovoj'),
(28	, 'Бескудниковский', 2, N'Beskudnikovskij'),
(29	, 'Бибирево', 2, N'Bibirevo'),
(30	, 'Бирюлёво Восточное', 2, N'Biryulyovo-Vostochnoe'),
(31	, 'Бирюлёво Западное', 2, N'Biryulyovo-Zapadnoe'),
(32	, 'Богородское', 2, N'Bogorodskoe'),
(33	, 'Братеево', 2, N'Brateevo'),
(34	, 'Бутово Северное', 2, N'Butovo-Severnoe'),
(35	, 'Бутово Южное', 2, N'Butovo-YUzhnoe'),
(36	, 'Бутырский', 2, N'Butyrskij'),
(37	, 'Вешняки', 2, N'Veshnyaki'),
(38	, 'Внуково', 2, N'Vnukovo'),
(39	, 'Войковский', 2, N'Vojkovskij'),
(40	, 'Восточный', 2, N'Vostochnyj'),
(41	, 'Выхино-Жулебино', 2, N'Vyhino-ZHulebino'),
(42	, 'Гагаринский', 2, N'Gagarinskij'),
(43	, 'Головинский', 2, N'Golovinskij'),
(44	, 'Гольяново', 2, N'Golyanovo'),
(45	, 'Даниловский', 2, N'Danilovskij'),
(46	, 'Дегунино Восточное', 2, N'Degunino-Vostochnoe'),
(47	, 'Дегунино Западное', 2, N'Degunino-Zapadnoe'),
(48	, 'Дмитровский', 2, N'Dmitrovskij'),
(49	, 'Донской', 2, N'Donskoj'),
(50	, 'Дорогомилово', 2, N'Dorogomilovo'),
(51	, 'Замоскворечье', 2, N'Zamoskvoreche'),
(52	, 'Зюзино', 2, N'Zyuzino'),
(53	, 'Зябликово', 2, N'Zyablikovo'),
(54	, 'Ивановское', 2, N'Ivanovskoe'),
(55	, 'Измайлово Восточное', 2, N'Izmajlovo-Vostochnoe'),
(56	, 'Измайлово', 2, N'Izmajlovo'),
(57	, 'Измайлово Северное', 2, N'Izmajlovo-Severnoe'),
(58	, 'Капотня', 2, N'Kapotnya'),
(59	, 'Коньково', 2, N'Konkovo'),
(60	, 'Коптево', 2, N'Koptevo'),
(61	, 'Косино-Ухтомский', 2, N'Kosino-Uhtomskij'),
(62	, 'Котловка', 2, N'Kotlovka'),
(63	, 'Красносельский', 2, N'Krasnoselskij'),
(64	, 'Крылатское', 2, N'Krylatskoe'),
(65	, 'Крюково', 2, N'Kryukovo'),
(66	, 'Кузьминки', 2, N'Kuzminki'),
(67	, 'Кунцево', 2, N'Kuncevo'),
(68	, 'Куркино,', 2, N'Kurkino'),
(69	, 'Левобережный', 2, N'Levoberezhnyj'),
(70	, 'Лефортово', 2, N'Lefortovo'),
(71	, 'Лианозово', 2, N'Lianozovo'),
(72	, 'Ломоносовский', 2, N'Lomonosovskij'),
(73	, 'Лосиноостровский', 2, N'Losinoostrovskij'),
(74	, 'Люблино', 2, N'Lyublino'),
(75	, 'Марфино', 2, N'Marfino'),
(76	, 'Марьина роща', 2, N'Marina-roshcha'),
(77	, 'Марьино', 2, N'Marino'),
(78	, 'Матушкино', 2, N'Matushkino'),
(79	, 'Медведково Северное', 2, N'Medvedkovo-Severnoe'),
(80	, 'Медведково Южное', 2, N'Medvedkovo-YUzhnoe'),
(81	, 'Метрогородок', 2, N'Metrogorodok'),
(82	, 'Мещанский', 2, N'Meshchanskij'),
(83	, 'Митино', 2, N'Mitino'),
(84	, 'Можайский', 2, N'Mozhajskij'),
(85	, 'Молжаниновский', 2, N'Molzhaninovskij'),
(86	, 'Москворечье-Сабурово', 2, N'Moskvoreche-Saburovo'),
(87	, 'Нагатино-Садовники', 2, N'Nagatino-Sadovniki'),
(88	, 'Нагатинский затон', 2, N'Nagatinskij-zaton'),
(89	, 'Нагорный', 2, N'Nagornyj'),
(90	, 'Некрасовка', 2, N'Nekrasovka'),
(91	, 'Нижегородский', 2, N'Nizhegorodskij'),
(92	, 'Ново-Переделкино', 2, N'Novo-Peredelkino'),
(93	, 'Новогиреево', 2, N'Novogireevo'),
(94	, 'Новокосино', 2, N'Novokosino'),
(95	, 'Обручевский', 2, N'Obruchevskij'),
(96	, 'Орехово-Борисово Северное', 2, N'Orekhovo-Borisovo-Severnoe'),
(97	, 'Орехово-Борисово Южное', 2, N'Orekhovo-Borisovo-YUzhnoe'),
(98	, 'Останкинский', 2, N'Ostankinskij'),
(99	, 'Отрадное', 2, N'Otradnoe'),
(100	, N'Очаково-Матвеевское', 2, N'Ochakovo-Matveevskoe'),
(101	, N'Перово', 2, N'Perovo'),
(102	, N'Печатники', 2, N'Pechatniki'),
(103	, N'Покровское-Стрешнево', 2, N'Pokrovskoe-Streshnevo'),
(104	, N'Преображенское', 2, N'Preobrazhenskoe'),
(105	, N'Пресненский', 2, N'Presnenskij'),
(106	, N'Проспект Вернадского', 2, N'Prospekt-Vernadskogo'),
(107	, N'Раменки', 2, N'Ramenki'),
(108	, N'Ростокино', 2, N'Rostokino'),
(109	, N'Рязанский', 2, N'Ryazanskij'),
(110	, N'Савёлки', 2, N'Savyolki'),
(111	, N'Савёловский', 2, N'Savyolovskij'),
(112	, N'Свиблово', 2, N'Sviblovo'),
(113	, N'Северный', 2, N'Severnyj'),
(114	, N'Силино', 2, N'Silino'),
(115	, N'Сокол', 2, N'Sokol'),
(116	, N'Соколиная гора', 2, N'Sokolinaya-gora'),
(117	, N'Сокольники', 2, N'Sokolniki'),
(118	, N'Солнцево', 2, N'Solncevo'),
(119	, N'Старое Крюково', 2, N'Staroe-Kryukovo'),
(120	, N'Строгино', 2, N'Strogino'),
(121	, N'Таганский', 2, N'Taganskij'),
(122	, N'Тверской', 2, N'Tverskoj'),
(123	, N'Текстильщики', 2, N'Tekstilshchiki'),
(124	, N'Тёплый Стан', 2, N'Tyoplyj-Stan'),
(125	, N'Тимирязевский', 2, N'Timiryazevskij'),
(126	, N'Тропарёво-Никулино', 2, N'Troparyovo-Nikulino'),
(127	, N'Тушино Северное', 2, N'Tushino-Severnoe'),
(128	, N'Тушино Южное', 2, N'Tushino-YUzhnoe'),
(129	, N'Филёвский парк', 2, N'Filyovskij-park'),
(130	, N'Фили-Давыдково', 2, N'Fili-Davydkovo'),
(131	, N'Хамовники', 2, N'Hamovniki'),
(132	, N'Ховрино', 2, N'Hovrino'),
(133	, N'Хорошёво-Мневники', 2, N'Horoshyovo-Mnevniki'),
(134	, N'Хорошёвский', 2, N'Horoshyovskij'),
(135	, N'Царицыно', 2, N'Caricyno'),
(136	, N'Черёмушки', 2, N'CHeryomushki'),
(137	, N'Чертаново Северное', 2, N'CHertanovo-Severnoe'),
(138	, N'Чертаново Центральное', 2, N'CHertanovo-Centralnoe'),
(139	, N'Чертаново Южное', 2, N'CHertanovo-YUzhnoe'),
(140	, N'Щукино', 2, N'SHCHukino'),
(141	, N'Южнопортовый', 2, N'YUzhnoportovyj'),
(142	, N'Якиманка', 2, N'YAkimanka'),
(143	, N'Ярославский', 2, N'YAroslavskij'),
(144	, N'Ясенево', 2, N'YAsenevo'),

-- mns, 3
(145,	N'Заводской', 3, N'Zavodskoj'),
(146,	N'Ленинский', 3, N'Leninskij'),
(147,	N'Московский', 3, N'Moskovskij'),
(148,	N'Октябрьский', 3, N'Oktyabrskij'),
(149,	N'Партизанский', 3, N'Partizanskij'),
(150,	N'Первомайский', 3, N'Pervomajskij'),
(151,	N'Советский', 3, N'Sovetskij'),
(152,	N'Фрунзенский', 3, N'Frunzenskij'),
(153,	N'Центральный', 3, N'Centralnyj'),
(154,	N'Академгородок', 3, N'Akademgorodok'),
(155,	N'Академия наук', 3, N'Akademiya-nauk'),
(156,	N'Ангарская', 3, N'Angarskaya'),
(157,	N'Аэродромная', 3, N'Aehrodromnaya'),
(158,	N'Боровляны', 3, N'Borovlyany'),
(159,	N'Восток', 3, N'Vostok'),
(160,	N'Восточный', 3, N'Vostochnyj'),
(161,	N'Ждановичи', 3, N'ZHdanovichi'),
(162,	N'Заславская', 3, N'Zaslavskaya'),
(163,	N'Зеленый луг', 3, N'Zelenyj-lug'),
(164,	N'Красный Бор', 3, N'Krasnyj-Bor'),
(165,	N'Курасовщина', 3, N'Kurasovshchina'),
(166,	N'Лошица', 3, N'Loshica'),
(167,	N'Малиновка', 3, N'Malinovka'),
(168,	N'Минск-Сити', 3, N'Minsk-Siti'),
(169,	N'Петровщина', 3, N'Petrovshchina'),
(170,	N'Серебрянка', 3, N'Serebryanka'),
(171,	N'Серова', 3, N'Serova'),
(172,	N'Сосны', 3, N'Sosny'),
(173,	N'Сухарево', 3, N'Suharevo'),
(174,	N'Уручье', 3, N'Uruche'),
(175,	N'Филиал БГУ', 3, N'Filial-BGU'),
(176,	N'Харьковская', 3, N'Harkovskaya'),
(177,	N'Цна', 3, N'Cna'),
(178,	N'Цнянка', 3, N'Cnyanka'),
(179,	N'Чижовка', 3, N'CHizhovka'),
(180,	N'Шабаны', 3, N'SHabany'),
(181,	N'Юго-Запад', 3, N'YUgo-Zapad'),

-- ekb, 4
(182,	N'Верх-Исетский', 4, N'Verh-Isetskij'),
(183,	N'Широкая Речка', 4, N'SHirokaya-Rechka'),
(184,	N'Гора Хрустальная', 4, N'Gora-Hrustalnaya'),
(185,	N'Лиственный', 4, N'Listvennyj'),
(186,	N'Перегон', 4, N'Peregon'),
(187,	N'Светлая Речка', 4, N'Svetlaya-Rechka'),
(188,	N'Академический', 4, N'Akademicheskij'),
(189,	N'ВИЗ', 4, N'VIZ'),
(190,	N'Заречный', 4, N'Zarechnyj'),
(191,	N'Железнодорожный', 4, N'ZHeleznodorozhnyj'),
(192,	N'Вокзальный', 4, N'Vokzalnyj'),
(193,	N'Горнозаводский', 4, N'Gornozavodskij'),
(194,	N'Палкино', 4, N'Palkino'),
(195,	N'Семь Ключей', 4, N'Sem-Klyuchej'),
(196,	N'Старая Сортировка', 4, N'Staraya-Sortirovka'),
(197,	N'Новая Сортировка', 4, N'Novaya-Sortirovka'),
(198,	N'Северный промышленный', 4, N'Severnyj-promyshlennyj'),
(199,	N'Сортировочный (Сортировка)', 4, N'Sortirovochnyj-Sortirovka'),
(200,	N'Кировский', 4, N'Kirovskij'),
(201,	N'ВТУЗгородок', 4, N'VTUZgorodok'),
(202,	N'Изоплит', 4, N'Izoplit'),
(203,	N'Калиновский', 4, N'Kalinovskij'),
(204,	N'Комсомольский (ЖБИ)', 4, N'Komsomolskij-ZHBI'),
(205,	N'Пионерский', 4, N'Pionerskij'),
(206,	N'Центральный (Центр)', 4, N'Centralnyj-Centr'),
(207,	N'Шарташ (Шарташский)', 4, N'SHartash-SHartashskij'),
(208,	N'Ленинский', 4, N'Leninskij'),
(209,	N'Юго-Западный', 4, N'YUgo-Zapadnyj'),
(210,	N'Московская горка', 4, N'Moskovskaya-gorka'),
(211,	N'УНЦ (Краснолесье)', 4, N'UNC-Krasnolese'),
(213,	N'Октябрьский', 4, N'Oktyabrskij'),
(214,	N'Кольцово', 4, N'Kolcovo'),
(215,	N'Компрессорный', 4, N'Kompressornyj'),
(216,	N'Малый Исток', 4, N'Malyj-Istok'),
(217,	N'Парковый', 4, N'Parkovyj'),
(218,	N'Сибирский', 4, N'Sibirskij'),
(219,	N'Синие Камни', 4, N'Sinie-Kamni'),
(220,	N'Глубокое', 4, N'Glubokoe'),
(221,	N'Мостовка', 4, N'Mostovka'),
(223,	N'Лечебный (Чапаевский)', 4, N'Lechebnyj-CHapaevskij'),
(224,	N'Птицефабрика', 4, N'Pticefabrika'),
(225,	N'Орджоникидзевский', 4, N'Ordzhonikidzevskij'),
(227,	N'Уралмаш', 4, N'Uralmash'),
(228,	N'Эльмаш', 4, N'EHlmash'),
(229,	N'Козловский', 4, N'Kozlovskij'),
(230,	N'Аппаратный', 4, N'Apparatnyj'),
(231,	N'Ягодный', 4, N'YAgodnyj'),
(232,	N'Чкаловский', 4, N'CHkalovskij'),
(233,	N'Ботанический', 4, N'Botanicheskij'),
(234,	N'Вторчермет', 4, N'Vtorchermet'),
(235,	N'Елизавет', 4, N'Elizavet'),
(236,	N'Нижне-Исетский (Нижне-Исетск)', 4, N'Nizhne-Isetskij'),
(237,	N'Рудный', 4, N'Rudnyj'),
(238,	N'Уктусский (Уктус)', 4, N'Uktusskij-Uktus'),
(239,	N'Химмаш', 4, N'Himmash'),
(240,	N'Южный (Автовокзал)', 4, N'YUzhnyj-Avtovokzal'),
(241,	N'Приисковый', 4, N'Priiskovyj'),
(242,	N'Хутор', 4, N'Hutor'),

-- nvs, 5
(243,	N'Дзержинский', 5, N'Dzerzhinskij'),
(244,	N'Железнодорожный', 5, N'ZHeleznodorozhnyj'),
(245,	N'Заельцовский', 5, N'Zaelcovskij'),
(246,	N'Калининский', 5, N'Kalininskij'),
(247,	N'Кировский', 5, N'Kirovskij'),
(248,	N'Ленинский', 5, N'Leninskij'),
(249,	N'Октябрьский', 5, N'Oktyabrskij'),
(250,	N'Первомайский', 5, N'Pervomajskij'),
(251,	N'Советский', 5, N'Sovetskij'),
(252,	N'Центральный', 5, N'Centralnyj'),

-- sam, 6
(253,	N'Железнодорожный', 6, N'ZHeleznodorozhnyj'),
(254,	N'Кировский', 6, N'Kirovskij'),
(255,	N'Красноглинский', 6, N'Krasnoglinskij'),
(256,	N'Куйбышевский', 6, N'Kujbyshevskij'),
(257,	N'Ленинский', 6, N'Leninskij'),
(258,	N'Октябрьский', 6, N'Oktyabrskij'),
(259,	N'Промышленный', 6, N'Promyshlennyj'),
(260,	N'Самарский', 6, N'Samarskij'),
(261,	N'Советский', 6, N'Sovetskij'),

-- rnd, 7
(262,	N'Ворошиловский', 7, N'Voroshilovskij'),
(263,	N'Железнодорожный', 7, N'ZHeleznodorozhnyj'),
(264,	N'Кировский', 7, N'Kirovskij'),
(265,	N'Ленинский', 7, N'Leninskij'),
(266,	N'Октябрьский', 7, N'Oktyabrskij'),
(267,	N'Первомайский', 7, N'Pervomajskij'),
(268,	N'Пролетарский', 7, N'Proletarskij'),
(269,	N'Советский', 7, N'Sovetskij'),
(270,	N'1-й п. Орджоникидзе', 7, N'1-j-Ordzhonikidze'),
(271,	N'2-й п. Орджоникидзе', 7, N'2-j-Ordzhonikidze'),
(272,	N'Александровка', 7, N'Aleksandrovka'),
(273,	N'Берберовка', 7, N'Berberovka'),
(274,	N'Болгарстрой', 7, N'Bolgarstroj'),
(275,	N'Верхнетемерницкий', 7, N'Verhnetemernickij'),
(276,	N'Военвед', 7, N'Voenved'),
(277,	N'ЗЖМ', 7, N'ZZHM'),
(278,	N'Змиевка', 7, N'Zmievka'),
(279,	N'Каменка', 7, N'Kamenka'),
(280,	N'Кирпичный', 7, N'Kirpichnyj'),
(281,	N'Левенцовский', 7, N'Levencovskij'),
(282,	N'Ленгородок', 7, N'Lengorodok'),
(283,	N'Мирный', 7, N'Mirnyj'),
(284,	N'Мясникован', 7, N'Myasnikovan'),
(285,	N'Нахичевань', 7, N'Nahichevan'),
(286,	N'Новое поселение', 7, N'Novoe-poselenie'),
(287,	N'Олимпиадовка', 7, N'Olimpiadovka'),
(288,	N'Рабочий городок', 7, N'Rabochij-gorodok'),
(289,	N'Сельмаш', 7, N'Selmash'),
(290,	N'СЖМ', 7, N'SZHM'),
(291,	N'Стройгородок', 7, N'Strojgorodok'),
(292,	N'Суворовский', 7, N'Suvorovskij'),
(293,	N'Темерник', 7, N'Temernik'),
(294,	N'Фрунзе', 7, N'Frunze'),
(295,	N'Чкаловский', 7, N'CHkalovskij'),

-- nng, 8
(296,	N'Автозаводский', 8, N'Avtozavodskij'),
(297,	N'Канавинский', 8, N'Kanavinskij'),
(298,	N'Ленинский', 8, N'Leninskij'),
(299,	N'Московский', 8, N'Moskovskij'),
(300,	N'Нижегородский', 8, N'Nizhegorodskij'),
(301,	N'Приокский', 8, N'Priokskij'),
(302,	N'Советский', 8, N'Sovetskij'),
(303,	N'Сормовский', 8, N'Sormovskij'),

-- che, 9
(304,	N'Центральный', 9, N'Centralnyj'),
(304,	N'Центр', 9, N'Centr'),
(304,	N'Тополиная Алея', 9, N'topolinaya aleya'),

(305,	N'Тракторозаводской', 9, N'Traktorozavodskoj'),
(305,	N'ЧТЗ', 9, N'chtz'),
(305,	N'Северо-Восток', 9, N'severo-vostok'),

(306,	N'Советский', 9, N'Sovetskij'),
(306,	N'АМЗ', 9, N'amz'),
(306,	N'Областная Больница', 9, N'Oblastnaya Bolnica'),

(307,	N'Ленинский', 9, N'Leninskij'),

(308,	N'Металлургический', 9, N'Metallurgicheskij'),
(308,	N'ЧМЗ', 9, N'chmz'),

(309,	N'Калининский', 9, N'Kalininskij'),
(309,	N'Северо-Запад', 9, N'severo-zapad'),

(310,	N'Курчатовский', 9, N'Kurchatovskij')

GO

UPDATE dbo.DistrictSeoParameter SET Value = N'Район: ' + Value
GO

INSERT INTO [dbo].[ArticleGroupSeoParameter]
           ([Value]
           ,[Alias]
           ,[ArticleGroupInternalName])
     VALUES
(N'снять квартиру', N'1k', N'1k'),
(N'снят квартира', N'snyat-kvartira', N'1k'),
(N'сниму квартиру', N'snimu-kvartiru', N'1k'),
(N'сдача квартир', N'sdacha-kvartir', N'1k'),
--(N'сдача квартиры', N'sdacha-kvartiry', N'1k'),
(N'аренда квартир', N'arenda-kvartir', N'1k'),
(N'съем квартиры', N'sem-kvartiry', N'1k'),
(N'сдам квартиру', N'sdam-kvartiru', N'1k'),

(N'снять 1 квартиру', N'snyat-1-kvartiru', N'1k'),
(N'снять 1 комнатную квартиру', N'1k-rent', N'1k'),
--(N'сниму 1 комнатную квартиру', N'snimu-1-komnatnuyu-kvartiru', N'1k'),
(N'сдача 1 комнатной квартиры', N'sdacha-1-komnatnoj-kvartiry', N'1k'),
(N'аренда 1 комнатной квартиры', N'arenda-1-komnatnoj-kvartiry', N'1k'),
(N'съем 1 комнатной квартиры', N'sem-1-komnatnoj-kvartiry', N'1k'),
--(N'сдам 1 комнатную квартиру', N'sdam-1-komnatnuyu-kvartiru', N'1k'),

(N'снять комнату', N'k', 'K'),
(N'снят комната', N'snyat-komnata', 'K'),
(N'сниму комнату', N'snimu-komnatu', 'K'),
(N'сдача комнат', N'sdacha-komnat', 'K'),
(N'сдача комнаты', N'sdacha-komnaty', 'K'),
(N'аренда комнат', N'arenda-komnat', 'K'),
(N'съем комнаты', N'sem-komnaty', 'K'),
(N'сдам комнату', N'sdam-komnatu', 'K'),

(N'снять студию', N'c', 'C'),
(N'сниму студию', N'snimu-studiyu', 'C'),
(N'студия сдача', N'studiya-sdacha', 'C'),
(N'аренда студии', N'arenda-studii', 'C'),
(N'съем студии', N'sem-studii', 'C'),
(N'сдам студию', N'sdam-studiyu', 'C'),

(N'снять 2 квартиру', N'snyat-2-kvartiru', '2k'),
(N'снять 2 комнатную квартиру', N'2k-rent', '2k'),
(N'сниму 2 комнатную квартиру', N'snimu-2-komnatnuyu-kvartiru', '2k'),
(N'сдача 2 комнатной квартиры', N'sdacha-2-komnatnoj-kvartiry', '2k'),
(N'аренда 2 комнатной квартиры', N'arenda-2-komnatnoj-kvartiry', '2k'),
(N'съем 2 комнатной квартиры', N'sem-2-komnatnoj-kvartiry', '2k'),
(N'сдам 2 комнатную квартиру', N'sdam-2-komnatnuyu-kvartiru', '2k'),

(N'снять 3 квартиру', N'snyat-3-kvartiru', '3k'),
(N'снять 3 комнатную квартиру', N'3k-rent', '3k'),
(N'сниму 3 комнатную квартиру', N'snimu-3-komnatnuyu-kvartiru', '3k'),
(N'сдача 3 комнатной квартиры', N'sdacha-3-komnatnoj-kvartiry', '3k'),
(N'аренда 3 комнатной квартиры', N'arenda-3-komnatnoj-kvartiry', '3k'),
(N'съем 3 комнатной квартиры', N'sem-3-komnatnoj-kvartiry', '3k'),
(N'сдам 3 комнатную квартиру', N'sdam-3-komnatnuyu-kvartiru', '3k'),
(N'сдаю 3 квартиру', N'sdayu-3-kvartiru', '3k'),

(N'снять квартиру комнату', N'snyat-kvartiru-komnatu', '1k,K'),
(N'сниму квартиру комнату', N'snimu-kvartiru-komnatu', '1k,K'),
(N'сдача квартир комнат', N'sdacha-kvartir-komnat', '1k,K'),
(N'сдача квартиры комнаты', N'sdacha-kvartiry-komnaty', '1k,K'),
(N'аренда квартир комнат', N'arenda-kvartir-komnat', '1k,K'),
(N'съем квартир комнат', N'sem-kvartir-komnat', '1k,K'),

(N'снять квартиру студию', N'snyat-kvartiru-studiyu', '1k,C'),
(N'сдача квартир студий', N'sdacha-kvartir-studii', '1k,C'),
(N'сдача квартиры студии', N'sdacha-kvartiry-studii', '1k,C'),
(N'аренда квартиры студии', N'arenda-kvartiry-studii', '1k,C'),
(N'квартиры студии съем', N'kvartiry-studii-sem', '1k,C'),

(N'снять 1 2 квартиру', N'snyat-1-2-kvartiru', '1k,2k'),
(N'снять 1 2 комнатную квартиру', N'1-2-rent', '1k,2k'),
(N'сниму 1 2 комнатную квартиру', N'snimu-1-2-komnatnuyu-kvartiru', '1k,2k'),
(N'аренда 1 2 комнатных квартир', N'arenda-1-2-komnatnoj-kvartiry', '1k,2k'),
(N'сдам 1 2 комнатную квартиру', N'sdam-1-2-komnatnuyu-kvartiru', '1k,2k'),

(N'снять 2 3 комнатную квартиру', N'2-3-rent', '2k,3k'),
(N'сниму 2 3 комнатную квартиру', N'snimu-2-3-komnatnuyu-kvartiru', '2k,3k'),
(N'аренда 2 3 комнатных квартир', N'arenda-2-3-komnatnoj-kvartiry', '2k,3k'),
(N'сдам 2 3 комнатную квартиру', N'sdam-2-3-komnatnuyu-kvartiru', '2k,3k'),

(N'снять 4 квартиру', N'snyat-4-kvartiru', '4k'),
(N'снять 4 комнатную квартиру', N'4k-rent', '4k'),
(N'аренда 4 комнатной квартиры', N'arenda-4-komnatnoj-kvartiry', '4k'),
(N'сдам 4 комнатную квартиру', N'sdam-4-komnatnuyu-kvartiru', '4k'),
(N'сдам 4 квартиру', N'sdam-4-kvartiru', '4k'),

(N'снять 5 квартиру', N'snyat-5-kvartiru', '5k'),
(N'снять 5 комнатную квартиру', N'5k-rent', '5k'),
(N'аренда 5 комнатной квартиры', N'arenda-5-komnatnoj-kvartiry', '5k'),
(N'сдаю 5 комнатную квартиру', N'sdaiy-5-komnatnuyu-kvartiru', '5k'),

(N'снять 3 4 комнатную квартиру', N'3-4-rent', '3k,4k'),
(N'сниму 3 4 комнатную квартиру', N'snimu-3-4-komnatnuyu-kvartiru', '3k,4k'),
(N'аренда 3 4 комнатных квартир', N'arenda-3-4-komnatnoj-kvartiry', '3k,4k')

GO

INSERT INTO [dbo].[PhraseSeoParameter]
           ([Value]
           ,[Alias])
     VALUES
(N'без посредников', N'wo-middlemans'),
(N'от собственника', N'by-owner'),
(N'без агента', N'wo-agents'),
(N'от хозяина', N'ot-hoyazina'),
(N'на длительный срок', N'na-dlitelnyj-srok'),
(N'на длительный срок без посредников', N'na-dlitelnyj-srok-wo-middlemans'),
(N'на длительный срок от собственника', N'na-dlitelnyj-srok-by-owner'),
(N'на длительный срок без агента', N'na-dlitelnyj-srok-wo-agents')

GO

-- CityId
-- 1	     Санкт-Петербург
-- 2	     Москва
-- 3	     Минск
-- 4	     Екатеринбург
-- 5	     Новосибирск
-- 6	     Самара
-- 7	     Ростов-на-Дону
-- 8	     Нижний Новгород
-- 9	     Челябинск
INSERT INTO [dbo].[AliasSeoParameter]
           ([Value]
           ,[Alias]
           ,[CityId]
           ,[DistrictId]
           ,[PriceFrom]
           ,[PriceTo]
           ,[ArticleGroupInternalName])
     VALUES
(N'снять квартиру в СПб недорого', N'snyat-kvartiru-v-SPb-nedorogo', 1, NULL, NULL, 25000, N'1k'),
(N'снять комнату в СПб недорого', N'snyat-komnatu-v-SPb-nedorogo', 1, NULL, NULL, 15000, N'K'),
(N'комната в СПб недорого', N'komnata-v-SPb-nedorogo', 1, NULL, NULL, 15000, N'K'),
(N'снять комнату СПб от хозяина недорого', N'snyat-komnatu-spb-ot-hozyaina-nedorogo', 1, NULL, NULL, 15000, N'K')

GO
