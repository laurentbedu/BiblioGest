﻿using BiblioGestSbyS.Models;
using System.ComponentModel;

namespace BiblioGestSbyS.ViewModels
{
    internal class LivreControlViewModel : ViewModelBase
    {
        private BindingList<dynamic> livreList;
        public BindingList<dynamic> LivreList
        {
            get
            {
                return livreList;

            }
            set
            {
                livreList = value;
                RaisePropertyChanged();
            }
        }

        private Livre selectedLivre;
        public Livre SelectedLivre
        {
            get => selectedLivre;
            set
            {
                if (selectedLivre != value)
                {
                    selectedLivre = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(() => SelectedLivreExemplairesList);
                }
            }
        }
        public BindingList<dynamic>? SelectedLivreExemplairesList
        {
            get
            {
                return GetSelectedLivreExemplairesList();
            }
        }
        private BindingList<dynamic> GetSelectedLivreExemplairesList()
        {
            BindingList<dynamic> list = new BindingList<dynamic>();
            foreach (Exemplaire exemplaire in SelectedLivre.ExemplairesList)
            {
                dynamic item = new
                {
                    exemplaire.Id,
                    exemplaire.Emplacement,
                    Edition = exemplaire.Editeur.Nom
                };
                list.Add(item);
            }
            return list;
        }

        public LivreControlViewModel()
        {
            List<dynamic> list = new List<dynamic>();
            foreach (Livre livre in Livre.jDA.GetAll())
            {
                string auteurs = string.Join(" / ", livre.AuteurList.Select(l => l.Nom + " " + l.Prenom[0] + "."));
                dynamic item = new
                {
                    livre.Id,
                    livre.Titre,
                    livre.Isbn,
                    Auteurs = auteurs,
                };
                list.Add(item);
            }
            list = list.OrderBy(it => it.Titre).ToList();
            LivreList = new BindingList<dynamic>(list);
            SelectedLivre = Livre.jDA.GetById(LivreList.First().Id);
        }



    }
}
