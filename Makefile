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


MOMA_EXE=$(TARGET)/MoMA.exe
MOMA_PDB=$(TARGET)/MoMA.exe.pdb
MOMA_SRC=DefinitionDownloader.Designer.cs \
	DefinitionDownloader.cs \
	MainForm.Designer.cs \
	MainForm.cs \
	Program.cs \
	Properties/AssemblyInfo.cs \
	WizardStep.cs

MOMA_RES=-resource:MoMA.DefinitionDownloader.resources \
	-resource:MoMA.MainForm.resources

MOMA_LINKRES=-linkresource:Resources/button_ok.png \
	-linkresource:Resources/list-add.png \
	-linkresource:Resources/monkey.png \
	-linkresource:Resources/spinner.gif \
	-linkresource:Resources/dialog-warning.png \
	-linkresource:Resources/list-remove.png \
	-linkresource:Resources/monoback.png
	

all:	$(MOMA_EXE)
$(MOMA_EXE): $(MOMA_SRC) 
	-mkdir -p $(TARGET)
	$(MCS) $(MCSFLAGS) -lib:. $(LIBS) -r:lib/MoMA.Analyzer.dll -r:System.dll -r:System.Drawing.dll -r:System.Data.dll -r:System.Web.dll -r:System.Xml.dll -r:System.EnterpriseServices -r:System.Web.Services -r:System.Windows.Forms  -target:winexe -out:$(MOMA_EXE) $(MOMA_RES) $(MOMA_SRC)
	chmod 0755 $(MOMA_EXE)

# common targets

all:	$(MOMA_EXE)

clean:
	-rm -f "$(MOMA_EXE)"* 2> /dev/null
	-rm -f "$(MOMA_PDB)" 2> /dev/null
	
# project names as targets

MoMA: $(MOMA_EXE)
