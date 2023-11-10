const charts = new Map();

const filter = document.getElementById('year');
const year = new Date().getFullYear();

const options = [year, year - 1, year - 2].map((year) => {
  const option = document.createElement('option');
  option.text = year;
  option.value = year;
  return option;
});

filter.append(...options);

filter.addEventListener('change', load);

async function load() {
  await buildSimulationsByInstitutionChart();
  await buildSimulationsByCourseChart();
  await buildConversionsByInstitutionChart();
  await buildConversionsByCourseChart();
}

async function buildSimulationsByInstitutionChart() {
  await fetchDataAndBuildPieChart('simulations-by-institution', 'pie');
}

async function buildSimulationsByCourseChart() {
  await fetchDataAndBuildPieChart('simulations-by-course', 'pie');
}

async function buildConversionsByInstitutionChart() {
  await fetchDataAndBuildPieChart('conversions-by-institution', 'doughnut');
}

async function buildConversionsByCourseChart() {
  await fetchDataAndBuildPieChart('conversions-by-course', 'doughnut');
}

async function fetchDataAndBuildPieChart(key, mode) {
  const canvas = document.getElementById(key);
  const response = await fetch(`/dashboard/${key}/${filter.value}`);
  const simulations = await response.json();
  const labels = Object.keys(simulations);
  const data = Object.values(simulations);
  buildPieChart(key, canvas, labels, data, mode);
}

function buildPieChart(key, canvas, labels, data, mode) {
  const cutouts = {
    pie: 0,
    doughnut: '50%',
  };

  const settings = {
    type: 'pie',
    data: {
      labels: labels,
      datasets: [
        {
          data: data,
          borderWidth: 0,
        },
      ],
    },
    options: {
      scales: {
        y: {
          beginAtZero: true,
        },
      },
      plugins: {
        legend: {
          position: 'left',
        },
      },
      cutout: cutouts[mode],
      maintainAspectRatio: false,
    },
  };

  if (charts.has(key)) {
    const chart = charts.get(key);
    chart.data = settings.data;
    chart.update();
  } else {
    const chart = new Chart(canvas, settings);
    charts.set(key, chart);
  }
}

load();
