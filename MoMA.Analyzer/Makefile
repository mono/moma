ifndef TARGET
	TARGET=./bin
else
	TARGET=./bin/$(TARGET)
endif

MCS=gmcs
RESGEN=resgen
ifndef (RELEASE)
	MCSFLAGS=-debug 
endif
LIBS=-lib:/usr/lib/mono/2.0


MOMA_ANALYZER_DLL=$(TARGET)/MoMA.Analyzer.dll
MOMA_ANALYZER_PDB=$(TARGET)/MoMA.Analyzer.dll.pdb
MOMA_ANALYZER_SRC=Analysis/BaseChecker.cs \
	AssemblyAnalyzer.cs \
	Definitions/FileDefinition.cs \
	Definitions/DefinitionHandler.cs \
	Results/BaseError.cs \
	Analysis/CheckMonoTodo.cs \
	Analysis/CheckPInvokes.cs \
	MethodExtractor.cs \
	Method.cs \
	Results/MissingMethodError.cs \
	Results/MonoTodoError.cs \
	Results/NotImplementedExceptionError.cs \
	Results/PInvokeError.cs \
	Properties/AssemblyInfo.cs \
	Web\ References/MoMAWebService/Reference.cs 

all:	$(MOMA_ANALYZER_DLL)
$(MOMA_ANALYZER_DLL): $(MOMA_ANALYZER_SRC) 
	-mkdir -p $(TARGET)
	$(MCS) $(MCSFLAGS) -lib:. $(LIBS) -r:ICSharpCode.SharpZipLib.dll -r:../lib/Mono.Cecil.dll -r:System.dll  -r:System.Data.dll -r:System.Web.dll -r:System.Xml.dll -r:System.EnterpriseServices -r:System.Web.Services  -target:library -out:$(MOMA_ANALYZER_DLL) $(MOMA_RES) $(MOMA_ANALYZER_SRC)
	chmod 0755 $(MOMA_ANALYZER_DLL)

# common targets

all:	$(MOMA_ANALYZER_DLL)

clean:
	-rm -f "$(MOMA_ANALYZER_DLL)"* 2> /dev/null
	-rm -f "$(MOMA_ANALYZER_PDB)" 2> /dev/null
	
# project names as targets

MoMA: $(MOMA_ANALYZER_DLL)