﻿Feature: Survival_HazardsDecreaseEvolutionStats_Become
	Чтобы избегать получение угроз выживания (голод/жажда)
	Как игроку
	Мне нужно, чтобы угрозы снижали характеристики характеристики модуля сражения.

@survival @dev0
Scenario Outline: Угрозы выживания (появляются в процессе) снижают характеристики модуля сражения у актёра игрока.
	Given Есть карта размером <mapSize>
	And Есть актёр игрока класса <personSid> в ячейке (<actorNodeX>, <actorNodeY>)
	When Я перемещаю персонажа на <moveDistance> клетку
	Then Актёр имеет характристику модуля сражения <combatStat> равную <combatStatValue>

Examples: 
| mapSize | personSid | actorNodeX | actorNodeY | moveDistance | expectedEffect | combatStat | combatStatValue |
| 2       | captain   | 0          | 0          | 50           | Слабый голод   | melee      | 8               |
| 2       | captain   | 0          | 0          | 75           | Голод          | melee      | 4               |
| 2       | captain   | 0          | 0          | 100          | Голодание      | melee      | 1               |

	