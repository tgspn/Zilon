﻿Feature: Perks_DefeatPerksAreLevelUp
	Чтобы была возможность развивать персонажей
	Как игроку
	Мне нужно, чтобы перк на убийство прокачивался после выполнения всех работ

@perks @dev0
Scenario: Один актёр убивает другого
	Given Квадратная карта
	And Два актёра на расстоянии атаки
	And У актёра игрока прогресс перка на убийство 4 из 5
	When Я атакую вражеского актёра
	And Я атакую вражеского актёра
	Then перк на убийство должен быть прокачен
