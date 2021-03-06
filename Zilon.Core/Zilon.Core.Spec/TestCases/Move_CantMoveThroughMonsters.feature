﻿Feature: Move_CantMoveThroughMonsters
	Чтобы игрок не мог долго убегать
	Как игроку
	Мне нужно, чтобы актёр не мог перемещаться сквозь монстров.

@move @dev0
Scenario: Запрет на перемещение актёра игрока сквозь моснтров
	Given Есть карта размером 2
	And Между ячейками (0, 0) и (1, 0) есть стена
	And Между ячейками (1, 0) и (0, 1) есть стена
	And Есть актёр игрока класса captain в ячейке (0, 0)
	And Есть монстр класса rat Id:100 в ячейке (0, 1)
	When Я выбираю ячейку (1, 0)
	Then Команда на перемещение не может выполняться
