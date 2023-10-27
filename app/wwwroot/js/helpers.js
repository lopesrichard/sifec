const Str = {
  reverse: (str) => str.split('').reverse().join(''),
  clean: {
    number: (str) => str.toString().replace(/[^0-9]/g, ''),
    alpha: (str) => str.toString().replace(/[^A-zÀ-ú]/g, ''),
    alnum: (str) => str.toString().replace(/[^A-zÀ-ú0-9]/g, ''),
  },
  convert: {
    float: (str, decimals = 2) =>
      str !== ''
        ? parseFloat(
            str
              .toString()
              .replace(/[^0-9,]/g, '')
              .replace(',', '.')
          ).toFixed(decimals)
        : '',
  },
};

const mask = (mask, string, reverse = false) => {
  return reverse ? reverseMask(mask, string) : doMask(mask, string);
};

const reverseMask = (mask, string) => {
  const result = doMask(Str.reverse(mask), Str.reverse(string));
  return Str.reverse(result);
};

const doMask = (mask, string = '') => {
  string = string.replace(/[\W]/g, '');
  let ret = '';
  for (let i = 0, j = 0; i <= mask.length - 1; i++) {
    if (string[j] === undefined) {
      break;
    }
    ret += mask[i] === '#' ? string[j++] : mask[i];
  }
  return ret;
};

mask.cpf = (cpf) => mask('###.###.###-##', cpf);
mask.cnpj = (cnpj) => mask('##.###.###/####-##', cnpj);
mask.document = (document) => (Str.clean.number(document).length >= 14 ? mask.cnpj(document) : mask.cpf(document));
mask.fixo = (fixo) => mask('(##) ####-####', fixo);
mask.celular = (celular) => mask('(##) #####-####', celular);
mask.telefone = (telefone) => (Str.clean.number(telefone).length >= 11 ? mask.celular(telefone) : mask.fixo(telefone));
mask.cep = (cep) => mask('#####-###', cep);

mask.money = (money, reverse = true) => {
  let string = money ? money.toString() : '';

  //Trata casos de float com apenas uma casa decimal vindos direto do banco de dados
  if (string.match(/[0-9]+\.[0-9]{1}$/)) {
    string += '0';
  }

  // Remove caracteres especiais
  const value = Str.clean.number(string);

  if (value == '') {
    return null;
  }

  const replaced = value.replace(/^0+/g, '');
  return 'R$ ' + mask('###.###,##', replaced.padStart(3, '0'), reverse);
};

mask.percentage = (money, reverse = true) => {
  const value = str.clean.number(money);

  if (value == '') {
    return null;
  }

  const str = value.toString();
  const replaced = str.replace(/^0+/g, '');

  return '% ' + mask('##,##', replaced.padStart(3, '0'), reverse);
};

const elements = document.querySelectorAll('[data-mask]');
elements.forEach((element) => {
  const type = element.dataset.mask;
  element.value = mask[type](element.value);
  element.addEventListener('input', () => {
    element.value = mask[type](element.value);
  });
});
