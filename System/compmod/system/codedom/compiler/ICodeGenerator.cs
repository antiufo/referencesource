//------------------------------------------------------------------------------
// <copyright file="ICodeGenerator.cs" company="Microsoft">
// 
// <OWNER>[....]</OWNER>
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace System.CodeDom.Compiler
{

    using System.Diagnostics;
    using System.IO;

    /// <devdoc>
    ///    <para>
    ///       Provides an
    ///       interface for code generation.
    ///    </para>
    /// </devdoc>
    public interface ICodeGenerator
    {
        /// <devdoc>
        bool IsValidIdentifier(string value);

        /// <devdoc>
        void ValidateIdentifier(string value);
        string CreateEscapedIdentifier(string value);

        string CreateValidIdentifier(string value);

        string GetTypeOutput(CodeTypeReference type);

        bool Supports(GeneratorSupport supports);

        void GenerateCodeFromExpression(CodeExpression e, TextWriter w, CodeGeneratorOptions o);

        void GenerateCodeFromStatement(CodeStatement e, TextWriter w, CodeGeneratorOptions o);

        void GenerateCodeFromNamespace(CodeNamespace e, TextWriter w, CodeGeneratorOptions o);

        void GenerateCodeFromCompileUnit(CodeCompileUnit e, TextWriter w, CodeGeneratorOptions o);

        /// <devdoc>
        void GenerateCodeFromType(CodeTypeDeclaration e, TextWriter w, CodeGeneratorOptions o);

    }
}
