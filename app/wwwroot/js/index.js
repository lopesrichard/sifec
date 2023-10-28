const cache = {
  courses: [],
  semesters: [],
  cities: [],
};

const values = {
  institution: '',
  course: '',
  semester: '',
  fee: '',
  name: '',
  document: '',
  email: '',
  city: '',
};

const form = document.getElementById('form');

const inputs = {
  institution: document.getElementById('institution'),
  course: document.getElementById('course'),
  semester: document.getElementById('semester'),
  fee: document.getElementById('fee'),
  name: document.getElementById('name'),
  document: document.getElementById('document'),
  email: document.getElementById('email'),
  city: document.getElementById('city'),
};

inputs.institution.addEventListener('input', (event) => (values.institution = event.target.value));
inputs.course.addEventListener('input', (event) => (values.course = event.target.value));
inputs.semester.addEventListener('input', (event) => (values.semester = event.target.value));
inputs.fee.addEventListener('input', (event) => (values.fee = event.target.value));
inputs.name.addEventListener('input', (event) => (values.name = event.target.value));
inputs.document.addEventListener('input', (event) => (values.document = event.target.value));
inputs.email.addEventListener('input', (event) => (values.email = event.target.value));
inputs.city.addEventListener('input', (event) => (values.city = event.target.value));

inputs.institution.addEventListener('change', async (event) => {
  await loadCourses();
});

inputs.course.addEventListener('change', () => {
  setSemesters();
});

const loadInstitutions = async () => {
  const response = await fetch('/institutions');
  const institutions = await response.json();
  const options = institutions.map((institution) => {
    const option = document.createElement('option');
    option.text = institution.name;
    option.value = institution.id;
    return option;
  });
  inputs.institution.append(...options);
};

const loadCourses = async () => {
  inputs.course.value = '';
  const response = await fetch(`/institutions/${institution.value}/courses`);
  const courses = await response.json();
  cache.courses = courses;
  const options = courses.map((course) => {
    const option = document.createElement('option');
    option.text = course.name;
    option.value = course.id;
    return option;
  });
  inputs.course.append(...options);
};

const setSemesters = () => {
  inputs.semester.value = '';

  const semesters = [];

  const { duration } = cache.courses.find((c) => c.id == course.value);

  for (let i = 1; i <= duration; i++) {
    semesters.push(i);
  }

  cache.semesters = semesters;

  const options = semesters.map((semester) => {
    const option = document.createElement('option');
    option.text = `${semester}º Semestre`;
    option.value = semester;
    return option;
  });

  const children = Array.from(inputs.semester.children);
  children.shift(); // selecione...
  children.forEach((child) => inputs.semester.removeChild(child));

  inputs.semester.append(...options);
};

const loadCities = async () => {
  course.value = '';
  const response = await fetch('/cities');
  const cities = await response.json();
  cache.cities = cities;
  const options = cities.map((city) => {
    const option = document.createElement('option');
    option.text = city.name;
    option.value = city.id;
    return option;
  });
  inputs.city.append(...options);
};

(async () => {
  await loadInstitutions();
})();

const steps = document.querySelectorAll('[data-step]');

const forward = document.getElementById('forward');
forward.addEventListener('click', async (event) => {
  event.preventDefault();
  steps[0].classList.add('d-none');
  steps[1].classList.remove('d-none');
  await loadCities();
});

const finish = document.getElementById('finish');
finish.addEventListener('click', async (event) => {
  event.preventDefault();
  values.fee = Str.convert.float(inputs.fee.value);
  const body = JSON.stringify(values);
  const response = await fetch('/simulations', {
    method: 'POST',
    body,
    headers: { 'content-type': 'application/json' },
  });
  const simulation = await response.json();
  const installment = document.getElementById('installment-value');
  const print = document.getElementById('print-link');
  installment.textContent = mask.money(simulation.installmentValue.toFixed(2));
  print.href = `/voucher/${simulation.id}`;
  steps[1].classList.add('d-none');
  steps[2].classList.remove('d-none');
});
