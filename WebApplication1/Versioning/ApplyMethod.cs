﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Versioning
{

    /// <summary>
    /// 
    /// </summary>
    public class RemoveVersionFromParameterv : IOperationFilter
    {

        /// <summary>
        /// 
        /// </summary>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters.Count > 0)
            {
                var versionparameter = operation.Parameters.SingleOrDefault(a => a.Name == "version");
                operation.Parameters.Remove(versionparameter);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ReplaceVersionWithExactValueInPath : IDocumentFilter
    {

        /// <summary>
        /// 
        /// </summary>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = swaggerDoc.Paths;
            swaggerDoc.Paths = new OpenApiPaths();
            foreach (var path in paths)
            {
                var key = path.Key.Replace("v{version}", swaggerDoc.Info.Version);
                var value = path.Value;
                swaggerDoc.Paths.Add(key, value);
            }
        }
    }
}