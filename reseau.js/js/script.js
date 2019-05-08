/**
 * Démonstration simple de réseaux de neuronnes
 * Inspiré de https://becominghuman.ai/making-a-simple-neural-network-2ea1de81ec20
 */

"use strict";

var App = {
    recompenses        : [0, 0, 0.5, 1],
    poids              : [0, 0, 0, 0],
    cible              : 1,
    tauxApprentissage  : 0.2
};

function evaluer(p) {
    var resultat = 0;
    App.recompenses.forEach(function(rec, indice) {
        resultat += (rec * p[indice]);
    });
    return resultat.toFixed(2);
}

function calculerErreur(desired, actual) {
  return (desired - actual);
}


function apprendre(erreur) {
    var nouveauxPoids = App.poids.slice(0);
    App.poids.forEach(function(weight, index) {
    if (App.recompenses[index] > 0) {
      if (erreur > 0) {
        nouveauxPoids[index] = weight + App.tauxApprentissage;
      } else {
        nouveauxPoids[index] = weight - App.tauxApprentissage;
      }
    }
    var nouvelleErreur = calculerErreur(App.cible, evaluer(nouveauxPoids));
    if (nouvelleErreur < erreur) {
      App.poids = nouveauxPoids;
    }
  });
}

/**
 * Lancement de la démonstration
 */
function demo() {
  for (var nbEssais =0; nbEssais < 50; nbEssais++) {

      var resultat = evaluer(App.poids);
      var erreur = calculerErreur(App.cible, resultat);

      window.console.log("Résultat avant : " + resultat);
      window.console.log("Erreur   avant : " + calculerErreur(App.cible, resultat));

      apprendre(erreur);
      window.console.log(App.poids);

      resultat = evaluer(App.poids);
      erreur = calculerErreur(App.cible, resultat);

      window.console.log("Résultat après : " + resultat);
      window.console.log("Erreur   après : " + calculerErreur(App.cible, resultat));
  }
}

/**
 * Initialiation de la page
 */
function initialiser() {
    document.getElementById("btn-principal").addEventListener("click", demo, false);

}

// Faire l'initialisation après le chargement de la page
window.addEventListener("load", initialiser, false);