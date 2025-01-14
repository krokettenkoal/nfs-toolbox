﻿using System.Collections.Generic;

namespace NfsCore.Reflection.Abstract
{
    /// <summary>
    /// Node that can be used for representing virtual hierarchy of collections in the database.
    /// </summary>
    public class VirtualNode
    {
        /// <summary>
        /// Name of the <see cref="VirtualNode"/> class.
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// List of child <see cref="VirtualNode"/> classes.
        /// </summary>
        public List<VirtualNode> SubNodes { get; set; }

        /// <summary>
        /// Default constructor: initializes instance of <see cref="VirtualNode"/> class.
        /// </summary>
        /// <param name="nodeName">Name of the <see cref="NodeName"/> property of 
        /// <see cref="VirtualNode"/> class.</param>
        public VirtualNode(string nodeName)
        {
            NodeName = nodeName;
            SubNodes = new List<VirtualNode>();
        }

        public override string ToString()
        {
            return $"{NodeName}: {SubNodes.Count} nodes";
        }
    }
}