﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Zilon.Core.Schemes;

namespace Zilon.Core.Persons
{
    public class PropFactory : IPropFactory
    {
        private readonly ISchemeService _schemeService;

        [ExcludeFromCodeCoverage]
        public PropFactory(ISchemeService schemeService)
        {
            _schemeService = schemeService;
        }

        public Equipment CreateEquipment(PropScheme scheme)
        {
            if (scheme.Equip == null)
            {
                throw new ArgumentException("Не корректная схема.", nameof(scheme));
            }


            var actSchemes = new List<TacticalActScheme>();
            var actSchemeSids = scheme.Equip.ActSids;

            if (scheme.Equip.ActSids != null)
            {
                foreach (var actSchemeSid in actSchemeSids)
                {

                    var actScheme = _schemeService.GetScheme<TacticalActScheme>(actSchemeSid);

                    actSchemes.Add(actScheme);
                }


                var equipment = new Equipment(scheme, actSchemes);

                return equipment;
            }
            else
            {
                return new Equipment(scheme, null);
            }
        }

        public Resource CreateResource(PropScheme scheme, int count)
        {
            var resource = new Resource(scheme, count);

            return resource;
        }
    }
}
