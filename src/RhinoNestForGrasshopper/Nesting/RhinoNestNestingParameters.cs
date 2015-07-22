﻿using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using RhinoNestForGrasshopper.Properties;

namespace RhinoNestForGrasshopper
{
    public class RhinoNestNestingParameters : GH_Component
    {

        private RhinoNestKernel.RhinoNestNestingParameters _parameters;
        /// <summary>
        /// Initializes a new instance of the RhinoNestNestingParameters class.
        /// </summary>
        public RhinoNestNestingParameters()
            : base("RhinoNestNestingParameters", "Nickname",
                "Description",
                 "RhinoNest", "Nesting")
        {
            _parameters = new RhinoNestKernel.RhinoNestNestingParameters();
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            if (_parameters ==null) _parameters = new RhinoNestKernel.RhinoNestNestingParameters();
            pManager.AddNumberParameter("Item to Item Distance", "I2I", "Item to Item Distance", GH_ParamAccess.item, _parameters.DistanceItemToItem);
            pManager.AddNumberParameter("Item to Sheet Distance", "I2S", "Item to Sheet Distance", GH_ParamAccess.item, _parameters.DistanceItemToSheet);
            pManager.AddNumberParameter("Limit of Variants", "LoV", "Limit of Variants", GH_ParamAccess.item, (double)  _parameters.LimitVariants);
            pManager.AddNumberParameter("Max time", "Mt", "Max time", GH_ParamAccess.item, (double)_parameters.TimeOut);
            pManager.AddNumberParameter("Precision", "P", "Precision", GH_ParamAccess.item, _parameters.DistancePrecision);
            pManager.AddNumberParameter("Precision", "P", "Precision", GH_ParamAccess.item, _parameters.DistancePrecision);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.Register_GenericParam("RhinoNest Nesting Parameters", "P", "RhinoNest Nesting Parameters");

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            double i2i = _parameters.DistanceItemToItem;
            double i2s = _parameters.DistanceItemToSheet;
            double limitOfVariants = (double) _parameters.LimitVariants;
            double timeOut = (double)_parameters.TimeOut;
            double precision = _parameters.DistancePrecision;

            if (DA.GetData(0, ref i2i)) _parameters.DistanceItemToItem = i2i;
            if (DA.GetData(1, ref i2s)) _parameters.DistanceItemToSheet = i2s;
            if (DA.GetData(2, ref limitOfVariants)) _parameters.LimitVariants = (int) limitOfVariants;
            if (DA.GetData(3, ref timeOut)) _parameters.TimeOut = (int)timeOut;
            if (DA.GetData(4, ref precision)) _parameters.DistancePrecision = precision;

            DA.SetData(0, _parameters);

        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                return Resources.IconRhinoNestParameters;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{f479ed14-13cd-4017-943b-853a7a0acb93}"); }
        }
    }
}