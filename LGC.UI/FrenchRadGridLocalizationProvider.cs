using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI.Localization;
using Telerik.WinControls.UI;

namespace LGC.UI
{
    public class FrenchRadGridLocalizationProvider : RadGridLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadGridStringId.FilterOperatorBetween: return "Entre";
                case RadGridStringId.FilterOperatorContains: return "Contient";
                case RadGridStringId.FilterOperatorDoesNotContain: return "Ne contient pas";
                case RadGridStringId.FilterOperatorEndsWith: return "se termine par";
                case RadGridStringId.FilterOperatorEqualTo: return "=";
                case RadGridStringId.FilterOperatorGreaterThan: return ">";
                case RadGridStringId.FilterOperatorGreaterThanOrEqualTo: return ">=";
                case RadGridStringId.FilterOperatorIsEmpty: return "Est vide";
                case RadGridStringId.FilterOperatorIsNull: return "Est null";
                case RadGridStringId.FilterOperatorLessThan: return "<";
                case RadGridStringId.FilterOperatorLessThanOrEqualTo: return "<=";
                case RadGridStringId.FilterOperatorNoFilter: return "Aucun filtre";
                case RadGridStringId.FilterOperatorNotBetween: return "Pas entre";
                case RadGridStringId.FilterOperatorNotEqualTo: return "!=";
                case RadGridStringId.FilterOperatorNotIsEmpty: return "Pas vide";
                case RadGridStringId.FilterOperatorNotIsNull: return "Pas null";
                case RadGridStringId.FilterOperatorStartsWith: return "commence par";
                case RadGridStringId.FilterOperatorIsLike: return "Est comme";
                case RadGridStringId.FilterOperatorNotIsLike: return "Pas comme";
                case RadGridStringId.FilterOperatorIsContainedIn: return "Est contenu dans";
                case RadGridStringId.FilterOperatorNotIsContainedIn: return "Pas contenu dans";

                case RadGridStringId.FilterOperatorCustom: return "Personnaliser";/////////

                case RadGridStringId.FilterFunctionBetween: return "Entre";
                case RadGridStringId.FilterFunctionContains: return "Contient";
                case RadGridStringId.FilterFunctionDoesNotContain: return "Ne contient pas";
                case RadGridStringId.FilterFunctionEndsWith: return "se termine par";
                case RadGridStringId.FilterFunctionEqualTo: return "=";
                case RadGridStringId.FilterFunctionGreaterThan: return ">";
                case RadGridStringId.FilterFunctionGreaterThanOrEqualTo: return ">=";
                case RadGridStringId.FilterFunctionIsEmpty: return "Est vide";
                case RadGridStringId.FilterFunctionIsNull: return "Est null";
                case RadGridStringId.FilterFunctionLessThan: return "<";
                case RadGridStringId.FilterFunctionLessThanOrEqualTo: return "<=";
                case RadGridStringId.FilterFunctionNoFilter: return "Aucun filtre";
                case RadGridStringId.FilterFunctionNotBetween: return "Pas entre";
                case RadGridStringId.FilterFunctionNotEqualTo: return "!=";
                case RadGridStringId.FilterFunctionNotIsEmpty: return "Pas vide:";
                case RadGridStringId.FilterFunctionNotIsNull: return "Pas null:";
                case RadGridStringId.FilterFunctionStartsWith: return "commence par:";
                case RadGridStringId.FilterFunctionCustom: return "Personnaliser:";
                case RadGridStringId.CustomFilterMenuItem: return "Commande de filtre personnalisé:";
                case RadGridStringId.CustomFilterDialogCaption: return " personnalisé le texte des boites de dialogue de Filtre:";
                case RadGridStringId.CustomFilterDialogLabel: return "personnalisée les Étiquettes des boites de dialogue de Filtre:";
                case RadGridStringId.CustomFilterDialogRbAnd: return "Et";
                case RadGridStringId.CustomFilterDialogRbOr: return "Ou";
                case RadGridStringId.CustomFilterDialogBtnOk: return "OK";
                case RadGridStringId.CustomFilterDialogBtnCancel: return "Annuler";
                case RadGridStringId.DeleteRowMenuItem: return "Supprimer la ligne";
                case RadGridStringId.SortAscendingMenuItem: return "Trier dans l'ordre croissant";
                case RadGridStringId.SortDescendingMenuItem: return "Trier dans l'ordre décroissant";
                case RadGridStringId.ClearSortingMenuItem: return "Effacer un élément de menu de tri";
                case RadGridStringId.ConditionalFormattingMenuItem: return "Mis en forme conditionnelle";
                case RadGridStringId.GroupByThisColumnMenuItem: return "Passen mit dieser Spalte";
                case RadGridStringId.UngroupThisColumn: return "Diese Spalte vom Gruppierung löschen";
                case RadGridStringId.ColumnChooserMenuItem: return "Spaltenwähler";
                case RadGridStringId.HideMenuItem: return "Cacher";
                case RadGridStringId.UnpinMenuItem: return "détacher";
                case RadGridStringId.PinMenuItem: return "Figer";
                case RadGridStringId.PinAtLeftMenuItem: return "Figer à gauche";
                case RadGridStringId.PinAtRightMenuItem: return "Figer à droite";
                case RadGridStringId.BestFitMenuItem: return "Meilleur ajustement";
                case RadGridStringId.PasteMenuItem: return "Insérer";
                case RadGridStringId.EditMenuItem: return "Modifier";
                case RadGridStringId.CopyMenuItem: return "Copier";
                case RadGridStringId.AddNewRowString: return "Cliquez ici pour insérer une nouvelle ligne";
                case RadGridStringId.ConditionalFormattingCaption: return "Editeur de mise en forme conditionnelle";
                case RadGridStringId.ConditionalFormattingLblColumn: return "colonne:";
                case RadGridStringId.ConditionalFormattingLblName: return "Nom:";
                case RadGridStringId.ConditionalFormattingLblType: return "Type:";
                case RadGridStringId.ConditionalFormattingRuleAppliesOn: return "Regel gilt für";
                case RadGridStringId.ConditionalFormattingLblValue1: return "Wert 1:";
                case RadGridStringId.ConditionalFormattingLblValue2: return "Wert 2:";
                case RadGridStringId.ConditionalFormattingGrpConditions: return "Auflagen";
                case RadGridStringId.ConditionalFormattingGrpProperties: return "Eigenschaften";
                case RadGridStringId.ConditionalFormattingChkApplyToRow: return "Auf Zeile anwenden";
                case RadGridStringId.ConditionalFormattingBtnAdd: return "Ansetzen";
                case RadGridStringId.ConditionalFormattingBtnRemove: return "Löschen";
                case RadGridStringId.ConditionalFormattingBtnOK: return "OK";
                case RadGridStringId.ConditionalFormattingBtnCancel: return "Annullieren";
                case RadGridStringId.ConditionalFormattingBtnApply: return "Anlegen";
                case RadGridStringId.ColumnChooserFormCaption: return "Spaltenwähler";
                case RadGridStringId.ColumnChooserFormMessage: return "Um eine Spalte zu verstecken,\nschieben Sie sie vom RadGridView\nauf dieses Fenster";
                case RadGridStringId.CustomFilterDialogCheckBoxNot: return "Pas";
                default: return base.GetLocalizedString(id);
            }
        }
    }


    class FrenchRadDockLocalizationProvider : RadDockLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadDockStringId.ContextMenuAutoHide: return "Masquer automatiquement";
                case RadDockStringId.ContextMenuCancel: return "Annuler";
                case RadDockStringId.ContextMenuClose: return "Fermer";
                case RadDockStringId.ContextMenuCloseAll: return "Fermer Tout";
                case RadDockStringId.ContextMenuCloseAllButThis: return "Termer tout sauf cet élément";
                case RadDockStringId.ContextMenuDockable: return "Encrable";
                case RadDockStringId.ContextMenuFloating: return "Flottant";
                case RadDockStringId.ContextMenuHide: return "Cacher";
                case RadDockStringId.ContextMenuMoveToNextTabGroup: return "Suivant";
                case RadDockStringId.ContextMenuMoveToPreviousTabGroup: return "Précédent";
                case RadDockStringId.ContextMenuNewHorizontalTabGroup: return "Onglet horizontal";
                case RadDockStringId.ContextMenuNewVerticalTabGroup: return "Onglet vertical";
                case RadDockStringId.ContextMenuTabbedDocument: return "Document";
                case RadDockStringId.DocumentTabStripCloseButton: return "!=";
                case RadDockStringId.DocumentTabStripListButton: return "Pas null";
                case RadDockStringId.ToolTabStripCloseButton: return "commence par";
                case RadDockStringId.ToolTabStripDockStateButton: return "Est comme";
                case RadDockStringId.ToolTabStripPinButton: return "Pas comme";
                case RadDockStringId.ToolTabStripUnpinButton: return "Est contenu dans";

                    
               
                default: return base.GetLocalizedString(id);
            }
        }
    }
}
