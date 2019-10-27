using System;
using System.IO;
using System.Reflection;
using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Passes;

namespace RaylibGenerator
{
    public class Library : ILibrary
    {
        public void Preprocess(Driver driver, ASTContext ctx)
        {
        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {
        }

        public void Setup(Driver driver)
        {
            var includeDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "include");
            var libraryDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lib");
            driver.Options.GeneratorKind = GeneratorKind.CSharp;
            var raylibModule = driver.Options.AddModule("raylib");
            raylibModule.OutputNamespace = "Raylib";
            raylibModule.IncludeDirs.Add(includeDirectory);
            raylibModule.Defines.Add("RAYGUI_IMPLEMENTATION");
            raylibModule.Defines.Add("RAYGUI_SUPPORT_RICONS");
            raylibModule.Headers.Add("raylib.h");
            raylibModule.Headers.Add("raymath.h");
            raylibModule.Headers.Add("physac.h");
            raylibModule.Headers.Add("easings.h");
            raylibModule.Headers.Add("raygui.h");
            raylibModule.Headers.Add("ricons.h");
            raylibModule.LibraryDirs.Add(libraryDirectory);
            raylibModule.Libraries.Add("raylib.dll");
        }

        public void SetupPasses(Driver driver)
        {
            driver.Context.TranslationUnitPasses.RenameDeclsUpperCase(RenameTargets.Any);
            driver.Context.TranslationUnitPasses.AddPass(new FunctionToInstanceMethodPass());
            driver.Context.TranslationUnitPasses.AddPass(new FieldToPropertyPass());
            driver.Context.TranslationUnitPasses.AddPass(new MarshalPrimitivePointersAsRefTypePass());
        }
    }
}