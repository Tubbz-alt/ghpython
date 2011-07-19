﻿using System;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Parameters.Hints;
using Rhino.Geometry;

namespace GhPython.Component
{
    class SpecialLineHint : GH_LineHint, IGH_TypeHint
    {
        PythonComponent _component;

        public SpecialLineHint(PythonComponent component)
        {
            if (component == null)
                throw new ArgumentNullException("component");

            _component = component;
        }

        bool IGH_TypeHint.Cast(object data, out object target)
        {
            bool toReturn = base.Cast(data, out target);

            if (toReturn &&
                _component.DocStorageMode == DocReplacement.DocStorage.AutomaticMarshal &&
                target != null)
            {
                Type t = target.GetType();

                if (t == typeof(Line))
                    target = new LineCurve((Line)target);
            }

            return toReturn;
        }
    }
}

