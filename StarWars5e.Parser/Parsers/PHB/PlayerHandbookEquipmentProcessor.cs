﻿using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars5e.Models.Enums;
using StarWars5e.Models.Equipment;

namespace StarWars5e.Parser.Parsers.PHB
{
    public class PlayerHandbookEquipmentProcessor: BaseProcessor<Equipment>
    {
        private readonly ExpandedContentEquipmentProcessor _expandedContentEquipmentProcessor;

        public PlayerHandbookEquipmentProcessor()
        {
            _expandedContentEquipmentProcessor = new ExpandedContentEquipmentProcessor();
        }

        public override async Task<List<Equipment>> FindBlocks(List<string> lines)
        {
            var equipmentList = new List<Equipment>();

            equipmentList.AddRange(await _expandedContentEquipmentProcessor.ParseWeapons(lines, "##### Blasters", ContentType.Core));
            equipmentList.AddRange(await _expandedContentEquipmentProcessor.ParseWeapons(lines, "##### Vibroweapons", ContentType.Core));
            equipmentList.AddRange(await _expandedContentEquipmentProcessor.ParseWeapons(lines, "##### Lightweapons", ContentType.Core));

            equipmentList.AddRange(await _expandedContentEquipmentProcessor.ParseArmor(lines, "##### Armor", ContentType.Core));

            equipmentList.AddRange(await _expandedContentEquipmentProcessor.ParseOtherEquipment(lines, "_Artisan's tools_", true, 1, ContentType.Core));
            equipmentList.AddRange(await _expandedContentEquipmentProcessor.ParseOtherEquipment(lines, "_Ammunition_", true, 2, ContentType.Core));
            equipmentList.AddRange(await _expandedContentEquipmentProcessor.ParseOtherEquipment(lines, "_Medical_", true, 2, ContentType.Core));

            return equipmentList;
        }
    }
}
